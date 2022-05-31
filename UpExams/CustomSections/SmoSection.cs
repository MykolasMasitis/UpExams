using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoSection
{
    public class CustomSection : ConfigurationSection
    {
        private static ConfigurationProperty _pBase;
        private static ConfigurationProperty _pNsi;
        private static ConfigurationProperty _pSmo; // это коллекция!

        private static ConfigurationPropertyCollection _pCollection;
        static CustomSection()
        {
            _pBase = new ConfigurationProperty("pBase", typeof(string));
            _pNsi = new ConfigurationProperty("pNsi", typeof(string));
            _pSmo = new ConfigurationProperty("companies", typeof(Companies));

            _pCollection = new ConfigurationPropertyCollection();
            _pCollection.Add(_pBase);
            _pCollection.Add(_pNsi);
            _pCollection.Add(_pSmo); // это коллекция!
        }
        [ConfigurationProperty("pBase")]
        public string pBase
        {
            get { return (string)base[_pBase]; }
        }
        [ConfigurationProperty("pBase")]
        public string pNsi
        {
            get { return (string)base[_pNsi]; }
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
        private static ConfigurationProperty _Folders;

        private static ConfigurationPropertyCollection _properties;
        static Company()
        {
            _qCod = new ConfigurationProperty("qCod", typeof(string));
            _qName = new ConfigurationProperty("qName", typeof(string));
            _qMail = new ConfigurationProperty("qMail", typeof(string));
            _Folders = new ConfigurationProperty("Folders", typeof(Folders));

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_qCod);
            _properties.Add(_qName);
            _properties.Add(_qMail);
            _properties.Add(_Folders);
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

        [ConfigurationProperty("Folders")]
        public Folders Nested
        {
            get { return (Folders)base[_Folders]; }
            set { base[_Folders] = value; }
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
    public class Folders : ConfigurationElement
    {
        private static ConfigurationProperty _pBase;
        private static ConfigurationProperty _pCommon;
        private static ConfigurationProperty _pStBase;
        private static ConfigurationProperty _pNsi;

        private static ConfigurationPropertyCollection _properties;
        static Folders()
        {
            _pBase = new ConfigurationProperty("pBase", typeof(string));
            _pCommon = new ConfigurationProperty("pCommon", typeof(string));
            _pStBase = new ConfigurationProperty("pStBase", typeof(string));
            _pNsi = new ConfigurationProperty("pNsi", typeof(string));

            _properties = new ConfigurationPropertyCollection();
            _properties.Add(_pBase);
            _properties.Add(_pCommon);
            _properties.Add(_pStBase);
            _properties.Add(_pNsi);
        }
        public Folders() { }
        [ConfigurationProperty("pBase")]
        public string pBase
        {
            get { return (string)base[_pBase]; }
            set { base[_pBase] = value; }
        }

        [ConfigurationProperty("pCommon")]
        public string pCommon
        {
            get { return (string)base[_pCommon]; }
            set { base[_pCommon] = value; }
        }

        [ConfigurationProperty("pStBase")]
        public string pStBase
        {
            get { return (string)base[_pStBase]; }
            set { base[_pStBase] = value; }
        }

        [ConfigurationProperty("pNsi")]
        public string pNsi
        {
            get { return (string)base[_pNsi]; }
            set { base[_pNsi] = value; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
}
