using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms.Queries
{
    /// <summary>
    /// Базовый класс иерархии дерева, применяемого для разбора запросов.
    /// </summary>
    public abstract class BaseNode
    {
        /// <summary>
        /// Конструктор по умолчанию.
        /// Устанавливает критерий в нуль.
        /// Оператор сравнения - ==.
        /// Логический оператор - &&.
        /// </summary>
        public BaseNode()
        {
            Criterium = string.Empty;
            ComparisonOperator = BooleanOperator.Equal;
            LogicOperator = BooleanOperator.LogicAnd;
        }
        
        /// <summary>
        /// Сформировать дерево запроса из типа.
        /// </summary>
        /// <param name="type">Тип записи БД.</param>
        /// <returns>Корень дерева запросов БД.</returns>
        public static BaseNode FromType(Type type)
        {
            var node = new SingleNode
            {
                Parent = null,
                Property = null
            };

            foreach (var prop in type.GetProperties())
                node.Nodes[prop.Name] = FromProperty(node, prop);

            return node;
        }

        internal static BaseNode FromProperty(BaseNode parent, PropertyInfo pi, int depth = 0)
        {
            BaseNode node;
            Type type;

            if (pi.PropertyType.Name.Contains("ICollection"))
            {
                node = new CollectionNode
                {
                    Parent = parent,
                    Property = pi
                };

                type = node.Property.PropertyType.GenericTypeArguments[0];

                if (depth < MaxDepth)
                    foreach (var prop in type.GetProperties())
                        if (parent.Property == null || parent.Property.PropertyType != prop.PropertyType)
                            node.Nodes[prop.Name] = FromProperty(node, prop, depth + 1);
            }
            else
            {
                node = new SingleNode
                {
                    Parent = parent,
                    Property = pi
                };

                type = node.Property.PropertyType;

                if (depth < MaxDepth && !IsBuiltin(type))
                    foreach (var prop in type.GetProperties())
                        if (parent.Property == null || parent.Property.PropertyType != prop.PropertyType)
                            node.Nodes[prop.Name] = FromProperty(node, prop, depth + 1);
            }

            return node;
        }

        /// <summary>
        /// Провести запрос по сущности, все критерии должны быть удовлетворены.
        /// </summary>
        /// <param name="entity">Объект, по которому проходит валидация.</param>
        /// <returns></returns>
        public bool Query(object entity)
        {
            bool result = true;

            try
            {
                SatisfyForNodes(entity, ref result);
            }
            catch
            {
                // result = false;
            }

            return result;
        }

        /// <summary>
        /// Привести название текущего узла.
        /// </summary>
        /// <returns>Строковое представление узла.</returns>
        public override string ToString()
        {
            return Property.Name ?? "User";
        }

        /// <summary>
        /// Метод проверки того, что объект удовлетворяет критериям.
        /// </summary>
        /// <param name="entity">Объект для проверки.</param>
        /// <returns>Удовлетворяет ли объект всем наложенным на него критериям.</returns>
        public abstract bool IsSatisfying(object entity);

        protected static bool IsBuiltin(Type type)
            => mBuiltins.Contains(type);

        protected void SatisfyForNodes(object entity, ref bool result)
        {
            foreach (var node in Nodes)
            {
                if (!result)
                    break;

                // Применяется выбранный оператор
                // result &= node.Value.IsSatisfying(fst);
                result = LogicOperator.Apply(
                    result,
                    node.Value.IsSatisfying(entity)
                );
            }
        }

        private const int MaxDepth = 1;

        /// <summary>
        /// Родительский узел.
        /// </summary>
        public BaseNode Parent { get; private set; }

        /// <summary>
        /// Информация о свойстве, который представляет текущий узел.
        /// </summary>
        public PropertyInfo Property { get; set; }

        /// <summary>
        /// Словарь потомков данного узла (имя -> узел).
        /// </summary>
        public Dictionary<string, BaseNode> Nodes = new Dictionary<string, BaseNode>();

        /// <summary>
        /// Строковое значение критерия.
        /// </summary>
        public string Criterium { get; set; }

        /// <summary>
        /// Оператор сравнения для данного узла.
        /// </summary>
        public BooleanOperator ComparisonOperator { get; set; }

        /// <summary>
        /// Логический оператор для проверки вложенных классов.
        /// </summary>
        public BooleanOperator LogicOperator { get; set; }

        private static readonly HashSet<Type> mBuiltins = new HashSet<Type>
            {
                typeof(byte), typeof(short), typeof(int), typeof(long),
                typeof(sbyte), typeof(ushort), typeof(uint), typeof(ulong),
                typeof(float), typeof(double), typeof(decimal),
                typeof(char), typeof(string),
                typeof(DateTime), typeof(DateTimeOffset),
            };
    }
}
