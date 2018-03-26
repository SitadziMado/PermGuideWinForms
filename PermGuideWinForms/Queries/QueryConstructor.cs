using System;
using System.Collections.Generic;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms.Queries
{
    /// <summary>
    /// Конструктор запросов для БД.
    /// </summary>
    public class QueryConstructor
    {        
        /// <summary>
        /// Создать конструктор для определенного типа данных.
        /// </summary>
        /// <param name="name">Имя данного экзепляра класса.</param>
        /// <param name="type">Тип, по которому следует строить конструктор.</param>
        public QueryConstructor(string name, Type type)
        {
            Root = BaseNode.FromType(type);
        }

        /// <summary>
        /// Найти узел по строковому пути.
        /// </summary>
        /// <param name="path">Путь по данной сущности (например, "UserRecord.Id").</param>
        /// <returns></returns>
        public BaseNode GetNode(string path)
        {
            var segments = path.Split('.');

            BaseNode cur = Root;

            try
            {
                foreach (var seg in segments)
                    cur = cur.Nodes[seg];
            }
            catch
            {
                throw;
            }

            return cur;
        }

        /// <summary>
        /// Провести запрос по данной коллекции и вывести только те, что удовлетворяют критериям.
        /// </summary>
        /// <param name="set">Коллекция для запроса.</param>
        /// <returns>Удовлетворяющие критериям объекты.</returns>
        public IEnumerable<object> Query(IEnumerable<object> set)
        {
            return from v
                   in set
                   where Root.Query(v)
                   select v;
        }

        /// <summary>
        /// Найти тип по строке в данной сборке.
        /// </summary>
        /// <param name="typename">Краткое имя типа.</param>
        /// <returns>Тип, найденный в данной сборке.</returns>
        public static Type GetThisAssemblyType(string typename)
        {
            var asm = Assembly.GetExecutingAssembly();
            var name = asm.GetName().Name;
            return Type.GetType($"{name}.{typename}", true);
        }

        /// <summary>
        /// Корень дерева для данного конструктора.
        /// </summary>
        public BaseNode Root { get; private set; }
    }
}