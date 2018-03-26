﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PermGuideWinForms
{
    static class Utility
    {
        public static void Jsonify<T>(this T item, Stream stream)
        {
            try
            {
                // using (var stream = File.Open(path, FileMode.Create))
                // {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                    try
                    {
                        using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                            stream, Encoding.UTF8, true, true, "  "))
                        {
                            var serializer = new DataContractJsonSerializer(typeof(T), mSettings);
                            serializer.WriteObject(writer, item);
                            writer.Flush();
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.ToString());
                    }
                    finally
                    {
                        Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                // }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }

        public static void Jsonify<T>(this T item, string path)
        {
            try
            {
                using (var stream = File.Open(path, FileMode.Create))
                    item.Jsonify(stream);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
            }
        }

        public static T FromJson<T>(Stream stream, params object[] constructorArgs)
        {
            try
            {
                // using (var stream = File.OpenRead(path))
                // {
                    var currentCulture = Thread.CurrentThread.CurrentCulture;
                    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

                    try
                    {
                        var serializer = new DataContractJsonSerializer(typeof(T), mSettings);
                        var item = (T)serializer.ReadObject(stream);

                        if (Equals(item, null))
                            throw new Exception();

                        return item;
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(exception.ToString());
                        return (T)Activator.CreateInstance(typeof(T), constructorArgs);
                    }
                    finally
                    {
                        Thread.CurrentThread.CurrentCulture = currentCulture;
                    }
                // }
            }
            catch
            {
                return (T)Activator.CreateInstance(typeof(T), constructorArgs);
            }
        }

        public static T FromJson<T>(string path, params object[] constructorArgs)
        {
            try
            {
                using (var stream = File.OpenRead(path))
                    return FromJson<T>(stream, constructorArgs);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.ToString());
                return (T)Activator.CreateInstance(typeof(T), constructorArgs);
            }
        }

        public static string Encrypt(this string password)
        {
            var data = mHasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            var sb = new StringBuilder();

            foreach (var c in data)
                sb.Append(c.ToString("x2"));

            return sb.ToString();
        }

        public static TResult PipeTo<TSource, TResult>(
            this TSource source,
            Func<TSource, TResult> func
        ) => func(source);

        public static TOutput Either<TInput, TOutput>(
            this TInput o, 
            Func<TInput, bool> condition,
            Func<TInput, TOutput> ifTrue, 
            Func<TInput, TOutput> ifFalse
        ) => condition(o) ? ifTrue(o) : ifFalse(o);

        public static TOutput Either<TInput, TOutput>(
            this TInput o, 
            Func<TInput, TOutput> ifTrue,
            Func<TInput, TOutput> ifFalse
        ) => o.Either(x => x != null, ifTrue, ifFalse);

        public static T Do<T>(this T obj, Action<T> action)
        {
            if (obj != null)
            {
                action(obj);
            }

            return obj;
        }

        /*public static Location AsLocation(this string str)
        {
            var coords = (
                    from v
                    in str.Split(',')
                    select int.Parse(v)
                ).ToArray();

            return new Location(
                coords[0],
                coords[1],
                coords[2]
            );
        }*/

        public static void Info(string text, string caption = "Информация")
        {
            MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        public static void Warn(string text, string caption = "Предупреждение")
        {
            MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

        }

        public static void Alert(string text, string caption = "Ошибка")
        {
            MessageBox.Show(
                text,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        public static string GetDescription<T>(this T enumerationValue)
            where T : struct
        {
            Type type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException("EnumerationValue must be of Enum type", "enumerationValue");
            }

            //Tries to find a DescriptionAttribute for a potential friendly name
            //for the enum
            MemberInfo[] memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    //Pull out the description value
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            //If we have no description attribute, just return the ToString of the enum
            return enumerationValue.ToString();
        }
        private static readonly DataContractJsonSerializerSettings mSettings =
            new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };

        private static MD5 mHasher = MD5.Create();
    }
}
