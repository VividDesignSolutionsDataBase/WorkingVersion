using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace ManageVar.Models
{
    public enum SourceData
    {
        None = 0,
        Application = 1,
        Cache = 2,
        Session = 3,
        Cookies  = 4
    }
    public class AppData
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public SourceData source { get; set; }
    }

    public class ListAppData : List<AppData>
    {
        const string Null = "<null>";
        const string ErrorToString = "<error when to string {0}>";
        private void AddNew(DictionaryEntry de, SourceData sd)
        {
            AppData ap = new AppData() { source = sd, Key = de.Key.ToString() };
            try
            {
                var obj = de.Value;
                ap.Value = (obj == null) ? Null : obj.ToString();
            }
            catch (Exception ex)
            {

                ap.Value = string.Format(ErrorToString, ex.Message);
            }
            this.Add(ap);
        }
        public void LoadFromSession()
        {
            var sess=HttpContext.Current.Session;
            foreach (var item in sess.Keys)
            {

                DictionaryEntry de = new DictionaryEntry(item, sess[item.ToString()]);
                AddNew(de, SourceData.Session);

            }
        }
        public void LoadFromApplication()
        {
           var data = HttpContext.Current.Application;
            foreach (var item in data.Keys)
            {
                DictionaryEntry de = new DictionaryEntry(item,  data[item.ToString()]);
                AddNew(de, SourceData.Application);
                
            }
        }
        public void LoadFromCache()
        {
           var data = HttpContext.Current.Cache.GetEnumerator();
            
            while(data.MoveNext())
            {
                var de = data.Entry;
                AddNew(de, SourceData.Cache);
            }
        }
        public void LoadFromCookies()
        {
           var data = HttpContext.Current.Request.Cookies;

            foreach (var item in data.Keys)
            {
                //TODO: handle HasKeys
                DictionaryEntry de = new DictionaryEntry(item, data[item.ToString()].Value);
                AddNew(de, SourceData.Cookies);
            }
        }


        internal void LoadAll()
        {
            LoadFromApplication();
            LoadFromSession();
            LoadFromCache();
            LoadFromCookies();

        }

        internal void DeleteItem(string Key, SourceData sd)
        {
            var ctx = HttpContext.Current;
            switch (sd)
            {
                case SourceData.Application:
                    ctx.Application.Remove(Key);
                    break;
                case SourceData.Cache:
                    ctx.Cache.Remove(Key);
                    break;
                case SourceData.Cookies:
                    ctx.Response.Cookies[Key].Expires = DateTime.Now.AddDays(-1);
                    break;
                case SourceData.Session:
                    ctx.Session.Remove(Key);
                    break;

            }
        }
    }
}