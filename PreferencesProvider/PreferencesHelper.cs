using System;
using System.Collections.Generic;
using Android.Content;

namespace PreferencesProvider
{
    public class PreferencesHelper
    {
        private ISharedPreferences isp;
        private ISharedPreferencesEditor edit;

        private FileCreationMode mode = FileCreationMode.MultiProcess;
        private string NamePreferences = "Data";

        public const string Setting = "Setting";
        public const string App = "App";
        public const string Cache = "Cache";
        public const string Tag = "Tags";

        public PreferencesHelper(Context context)
        {
            isp = context.GetSharedPreferences(NamePreferences, mode);
            edit = isp.Edit();
        }
        public PreferencesHelper(Context context, string Name_Preferences)
        {
            isp = context.GetSharedPreferences(Name_Preferences, mode);
            edit = isp.Edit();
        }
        public PreferencesHelper(Context context, string Name_Preferences, FileCreationMode File_mode)
        {
            isp = context.GetSharedPreferences(Name_Preferences, File_mode);
            edit = isp.Edit();
        }
        public void Set<T>(string key, T value)
        {
            if (value is bool)
                edit.PutBoolean(key, Convert.ToBoolean(value));

            if (value is string)
                edit.PutString(key, Convert.ToString(value));

            if (value is float)
                edit.PutFloat(key, Convert.ToSingle(value));

            if (value is int)
                edit.PutInt(key, Convert.ToInt32(value));

            if (value is long)
                edit.PutLong(key, Convert.ToInt64(value));

            edit.Commit();
        }

        public object Get<T>(string key, T def)
        {

            if (def is bool)
                return isp.GetBoolean(key, Convert.ToBoolean(def));

            if (def is string)
                return isp.GetString(key, Convert.ToString(def));

            if (def is float)
                return isp.GetFloat(key, Convert.ToSingle(def));

            if (def is int)
                return isp.GetInt(key, Convert.ToInt32(def));

            if (def is long)
                return isp.GetLong(key, Convert.ToInt64(def));

            return null;
        }

        public IDictionary<string, object> All
        {
            get
            {
                return isp.All;
            }
        }

        public bool Exist(string key)
        {
            return isp.Contains(key);
        }

        public void Delete(string key)
        {
            edit.Remove(key);
            edit.Commit();
        }

        public void Claer(bool tf)
        {
            if (tf)
            {
                edit.Clear();
                edit.Commit();
            }
        }

    }
}