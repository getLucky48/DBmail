using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace WindowsFormsApp2.KernelObject
{

    public abstract class KernelObject
    {

        public Guid id { get; set; }

        public string tableName { get; set; }

        public static List<T> GetList<T>() where T : KernelObject, new()
        {

            T tempObj = new T();

            StringBuilder builder = new StringBuilder();

            builder.AppendLine(tempObj.prepare_query_select());
            builder.AppendLine(tempObj.prepare_query_from());
            builder.AppendLine(tempObj.prepare_query_where());

            List<T> list = new List<T>();

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(builder.ToString(), connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                T currObj = new T();
                currObj.FillByReader(reader);
                list.Add(currObj);
            }

            connection.Close();

            return list;

        }

        public static T GetByID<T>(Guid id) where T : KernelObject, new()
        {

            T tempObj = new T();

            StringBuilder builder = new StringBuilder();

            builder.AppendLine(tempObj.prepare_query_select());
            builder.AppendLine(tempObj.prepare_query_from());
            builder.AppendLine(tempObj.prepare_query_where());
            builder.AppendLine($"and {tempObj.tableName}_alias.id = '{id}'");

            NpgsqlConnection connection = DBUtils.getConnection();

            connection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(builder.ToString(), connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            T currObj = new T();

            while (reader.Read())
            {
                currObj.FillByReader(reader);
                break;
            }

            connection.Close();

            return currObj;

        }

        protected abstract void FillByReader(NpgsqlDataReader reader);

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual void Delete()
        {

            string query = $"call delete_{tableName}('{id}')";

            DBUtils.execQuery(query);

        }

        public virtual string prepare_query_select()
        {

            string query = $" select * ";

            return query;

        }

        public virtual string prepare_query_from()
        {

            string query = $" from {this.tableName} {this.tableName}_alias ";

            return query;

        }

        public virtual string prepare_query_where()
        {

            string query = $" where 1 = 1 ";

            return query;

        }

    }

}
