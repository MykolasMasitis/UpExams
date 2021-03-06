using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSection
{
    public class CustomSection : ConfigurationSection
    {
        private static ConfigurationProperty _pSmo; // это коллекция!

        private static ConfigurationPropertyCollection _pCollection;
        static CustomSection()
        {
            _pSmo = new ConfigurationProperty("companies", typeof(Companies));

            _pCollection = new ConfigurationPropertyCollection();
            _pCollection.Add(_pSmo); // это коллекция!
        }
        public Companies companies
        {
            get { return (Companies)base[_pSmo]; } // это коллекция!
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _pCollection; }
        }
    }
 
    [ConfigurationCollection(typeof(Company), AddItemName = "company", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class Companies : ConfigurationElementCollection
    {
        public Companies() { }
        private static ConfigurationPropertyCollection _properties;
        static Companies() { _properties = new ConfigurationPropertyCollection(); }
        protected override ConfigurationPropertyCollection Properties { get { return _properties; } }

        //public override ConfigurationElementCollectionType CollectionType { get { return ConfigurationElementCollectionType.AddRemoveClearMap; } }
        public override ConfigurationElementCollectionType CollectionType { get { return ConfigurationElementCollectionType.BasicMap; } }
        public Company this[int index]
        {
            get { return (Company)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                    base.BaseRemoveAt(index);
                base.BaseAdd(index, value);
            }
        }
        public override bool IsReadOnly()
        {
            return false;
        }
        public new Company this[string name]
        {
            get { return (Company)base.BaseGet(name); }
        }
        // Необходимо только для типа BasicMap!
        protected override string ElementName
        {
            get { return "company"; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new Company();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as Company).qCod;
        }
        #region Методы ниже необходимы для редактирования коллекции и сохранения в App.config
        public void Add(Company q)
        {
            base.BaseAdd(q);
        }

        public void Remove(string name)
        {
            base.BaseRemove(name);
        }

        public void Remove(Company q)
        {
            base.BaseRemove(GetElementKey(q));
        }
        // 
        public void Clear()
        {
            base.BaseClear();
        }

        public void RemoveAt(int index)
        {
            base.BaseRemoveAt(index);
        }

        public string GetKey(int index)
        {
            return (string)base.BaseGetKey(index);
        }
        #endregion
    }
    public class Company : ConfigurationElement
    {
        private static ConfigurationProperty _qCod;
        private static ConfigurationProperty _qName;
        private static ConfigurationProperty _qMail;
        private static ConfigurationProperty _AuthInfo;

        private static ConfigurationPropertyCollection _properties;
        static Company()
        {
            _qCod = new ConfigurationProperty("qCod", typeof(string));
            _qName = new ConfigurationProperty("qName", typeof(string));
            _qMail = new ConfigurationProperty("qMail", typeof(string));
            _AuthInfo = new ConfigurationProperty("AuthInfo", typeof(AuthInfo));

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_qCod);
            _properties.Add(_qName);
            _properties.Add(_qMail);
            _properties.Add(_AuthInfo);
        }
        public Company() { }
        [ConfigurationProperty("qCod")]
        public string qCod
        {
            get { return (string)base[_qCod]; }
            set { base[_qCod] = value; }
        }

        [ConfigurationProperty("qName")]
        public string qName
        {
            get { return (string)base[_qName]; }
            set { base[_qName] = value; }
        }

        [ConfigurationProperty("qMail")]
        public string qMail
        {
            get { return (string)base[_qMail]; }
            set { base[_qMail] = value; }
        }

        [ConfigurationProperty("AuthInfo")]
        public AuthInfo Nested
        {
            get { return (AuthInfo)base[_AuthInfo]; }
            set { base[_AuthInfo] = value; }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
    public class AuthInfo : ConfigurationElement
    {
        private static ConfigurationProperty _orgId;
        private static ConfigurationProperty _system;
        private static ConfigurationProperty _login;
        private static ConfigurationProperty _password;

        private static ConfigurationPropertyCollection _properties;
        static AuthInfo()
        {
            _orgId = new ConfigurationProperty("orgId", typeof(string));
            _system = new ConfigurationProperty("system", typeof(string));
            _login = new ConfigurationProperty("login", typeof(string));
            _password = new ConfigurationProperty("password", typeof(string));

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_orgId);
            _properties.Add(_system);
            _properties.Add(_login);
            _properties.Add(_password);
        }
        public AuthInfo() { }

        [ConfigurationProperty("orgId")]
        public string orgId
        {
            get { return (string)base[_orgId]; }
            set { base[_orgId] = value; }
        }

        [ConfigurationProperty("system")]
        public string system
        {
            get { return (string)base[_system]; }
            set { base[_system] = value; }
        }

        [ConfigurationProperty("login")]
        public string login
        {
            get { return (string)base[_login]; }
            set { base[_login] = value; }
        }

        [ConfigurationProperty("password")]
        public string password
        {
            get { return (string)base[_password]; }
            set { base[_password] = value; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
}
