using System.IO;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace PortalKol.Core.Infrastructure.Data
{
    public interface ISessionFactoryProvider
    {
        ISessionFactory GetSessionFactory();
    }

    public class SessionFactoryProvider : ISessionFactoryProvider
    {
        private ISessionFactory _sessionFactory;
        private readonly ISessionFactoryConfigurator _configurator;

        public SessionFactoryProvider(ISessionFactoryConfigurator configurator)
        {
            _configurator = configurator;
        }

        public ISessionFactory GetSessionFactory()
        {
            return _sessionFactory ?? (_sessionFactory = CreateConfiguration().BuildSessionFactory());
        }

        private Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            _configurator.Configure(configuration);
            AddMappings(configuration);
            AddEventListeners(configuration);

            new SchemaExport(configuration).Execute(s => Schema.Sql = Schema.Sql + s, false, false);

            return configuration;
        }

        private static void AddEventListeners(Configuration configuration)
        {
            //FOR FUTURE...
            /*configuration.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] { new AuditEventListener() };
            configuration.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] { new AuditEventListener() };*/
        }

        private static void AddMappings(Configuration configuration)
        {
            var mapper = new ConventionModelMapper();

            ApplyConventions(mapper);

            var localTypes = typeof(SessionFactoryProvider).Assembly.GetExportedTypes();

            // add explicitly declared class mappings (implementations of ClassMapping<T>)
            mapper.AddMappings(localTypes);

            // create mappings for all entities
            // will use conventions and explicily declared mappings
            var mapping = mapper.CompileMappingFor(localTypes);
            Schema.Hbm = mapping.AsString();
            configuration.AddMapping(mapping);


        }

        private static void ApplyConventions(ConventionModelMapper mapper)
        {
            var baseEntityType = typeof(Entity);
            mapper.IsEntity((t, d) => baseEntityType.IsAssignableFrom(t) && t != baseEntityType & !t.IsInterface);
            mapper.IsRootEntity((t, m) => baseEntityType == t.BaseType);

            mapper.BeforeMapManyToOne += (inspector, member, customizer) =>
            {
                customizer.Column(member.LocalMember.Name + "Id");
                customizer.Cascade(Cascade.Persist);
            };

            mapper.BeforeMapBag += (inspector, member, customizer) =>
            {
                customizer.Key(x => x.Column(member.GetContainerEntity(inspector).Name + "Id"));
                customizer.Cascade(Cascade.All | Cascade.DeleteOrphans);
            };
            mapper.BeforeMapSet += (inspector, member, customizer) =>
            {
                customizer.Key(x => x.Column(member.GetContainerEntity(inspector).Name + "Id"));
                customizer.Cascade(Cascade.All | Cascade.DeleteOrphans);
            };
            mapper.BeforeMapManyToMany += (inspector, member, customizer) =>
            {
                var memberType = member.LocalMember.GetPropertyOrFieldType();
                if (memberType.IsGenericType)
                {
                    var t = memberType.GetGenericArguments()[0];
                    customizer.Column(t.Name + "Id");
                }
            };

            //FOR FUTURE..
            /*var baseEntityType = typeof(Entity);
            var baseComponentType = typeof(Component);
            mapper.IsRootEntity((t, m) => t.BaseType == typeof(MonthlyVector) || baseEntityType == t.BaseType);
            mapper.IsComponent((t, d) => baseComponentType.IsAssignableFrom(t) && baseComponentType != t);

            mapper.Class<Entity>(map =>
            {
                map.Id(x => x.Id, m => m.Generator(Generators.HighLow, gen =>
                    gen.Params(new { table = "HiLoValue", column = "NextHigh", max_lo = 100 })));
                map.Version(x => x.Version, m => { });
                map.Property(x => x.CreatedBy, cb => cb.Length(50));
                map.Property(x => x.ModifiedBy, mb => mb.Length(50));
            });

            // do not map indexer properties (like this[int index])
            mapper.IsPersistentProperty((member, declared) =>
                declared || (member is PropertyInfo && ((PropertyInfo)member).GetIndexParameters().Length == 0));

            mapper.BeforeMapBag += (inspector, member, customizer) =>
            {
                customizer.Key(x => x.Column(member.GetContainerEntity(inspector).Name + "Id"));
                customizer.Cascade(Cascade.All | Cascade.DeleteOrphans);
            };
            mapper.BeforeMapSet += (inspector, member, customizer) =>
            {
                customizer.Key(x => x.Column(member.GetContainerEntity(inspector).Name + "Id"));
                customizer.Cascade(Cascade.All | Cascade.DeleteOrphans);
            };
            mapper.BeforeMapManyToOne += (inspector, member, customizer) =>
            {
                customizer.Column(member.LocalMember.Name + "Id");
                customizer.Cascade(Cascade.Persist);
            };
            mapper.BeforeMapManyToMany += (inspector, member, customizer) =>
            {
                var memberType = member.LocalMember.GetPropertyOrFieldType();
                if (memberType.IsGenericType)
                {
                    var t = memberType.GetGenericArguments()[0];
                    customizer.Column(t.Name + "Id");
                }
            };

            mapper.BeforeMapProperty += (inspector, member, customizer) =>
            {
                var property = member.LocalMember;
                var type = property.GetPropertyOrFieldType();

                if (type.IsEnum)
                {
                    customizer.Column(c => c.SqlType("tinyint"));
                    customizer.NotNullable(true);
                }
                else if (type == typeof(string))
                    customizer.Length(255);
                else if (type == typeof(bool))
                    customizer.NotNullable(true);

                // component properties will have columns named ComponentProperty, eg. AddressStreet
                if (inspector.IsComponent(property.DeclaringType))
                {
                    customizer.Column(member.PreviousPath.LocalMember.Name + property.Name);
                }
            };

            mapper.BeforeMapElement += (inspector, member, customizer) =>
            {
                customizer.Column("Value");
                if (member.LocalMember.GetPropertyOrFieldType().IsEnum)
                    customizer.Column(c => c.SqlType("tinyint"));
            };*/
        }
    }

    public static class Schema
    {
        private static string _sql;
        public static string Hbm { get; set; }

        public static string Sql
        {
            get { return _sql; }
            set { _sql = value.Replace("\n", "</br>"); }
        }
    }
}