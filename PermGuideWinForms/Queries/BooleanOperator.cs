using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PermGuideWinForms.Queries
{
    /// <summary>
    /// Класс для работы с операторами.
    /// </summary>
    public class BooleanOperator
    {
        private BooleanOperator()
        {

        }

        /// <summary>
        /// Создание своего оператора из бинарного предиката.
        /// </summary>
        /// <param name="func"></param>
        public BooleanOperator(Func<object, object, bool> func)
        {
            mFunc = func;
        }

        /// <summary>
        /// Создание оператора из строки, представляющей оператор.
        /// </summary>
        /// <param name="op">Строка оператора.</param>
        /// <returns>Сконструированный оператор.</returns>
        public static BooleanOperator FromString(string op)
        {
            BooleanOperator self;

            try
            {
                self = new BooleanOperator
                {
                    mFunc = mOperators[op]
                };
            }
            catch (KeyNotFoundException)
            {
                throw;
            }

            return self;
        }

        /// <summary>
        /// Применить оператор к объекту.
        /// Важно соблюдать равенство типов и учитывать сравнимость объектов.
        /// </summary>
        /// <param name="lhs">Первый объект.</param>
        /// <param name="rhs">Второй объект.</param>
        /// <returns>Значение оператора.</returns>
        public bool Apply(object lhs, object rhs)
        {
            return mFunc(lhs, rhs);
        }

        private static int Compare(object lhs, object rhs)
        {
            int result;

            try
            {
                var fst = (IComparable)lhs;
                var snd = (IComparable)rhs;
                result = fst.CompareTo(snd);
            }
            catch (InvalidCastException)
            {
                throw new IncomparableObjectsException();
            }

            return result;
        }

        private static bool Bool(object boolean)
        {
            bool result;

            try
            {
                result = (bool)boolean;
            }
            catch (InvalidCastException)
            {
                throw new IncomparableObjectsException();
            }

            return result;
        }

        private static Dictionary<string, Func<object, object, bool>> mOperators =
            new Dictionary<string, Func<object, object, bool>>
            {
                { EQ, (x, y) => x.Equals(y) },
                { NE, (x, y) => !x.Equals(y) },
                { LT, (x, y) => Compare(x, y) < 0 },
                { GT, (x, y) => Compare(x, y) > 0 },
                { LE, (x, y) => Compare(x, y) <= 0 },
                { GE, (x, y) => Compare(x, y) >= 0 },
                { AndString, (x, y) => Bool(x) && Bool(y) },
                { OrString, (x, y) => Bool(x) || Bool(y) },
            };

        /// <summary>
        /// Оператор равенства (==)
        /// </summary>
        public static readonly BooleanOperator Equal = FromString(EQ);

        /// <summary>
        /// Оператор неравенства (!=)
        /// </summary>
        public static readonly BooleanOperator NotEqual = FromString(NE);

        /// <summary>
        /// Оператор меньше (&lt;)
        /// </summary>
        public static readonly BooleanOperator LessThan = FromString(LT);

        /// <summary>
        /// Оператор больше (&gt;)
        /// </summary>
        public static readonly BooleanOperator GreaterThan = FromString(GT);

        /// <summary>
        /// Оператор меньше или равно (&lt;=)
        /// </summary>
        public static readonly BooleanOperator LessThanOrEqual = FromString(LE);

        /// <summary>
        /// Оператор больше или равно (&gt;=)
        /// </summary>
        public static readonly BooleanOperator GreaterThanOrEqual = FromString(GE);

        /// <summary>
        /// Оператор логическое И (&amp;&amp;)
        /// </summary>
        public static readonly BooleanOperator LogicAnd = FromString(AndString);

        /// <summary>
        /// Оператор логическое ИЛИ (||)
        /// </summary>
        public static readonly BooleanOperator LogicOr = FromString(OrString);

        private const string EQ = "==";
        private const string NE = "!=";
        private const string LT = "<";
        private const string GT = ">";
        private const string LE = "<=";
        private const string GE = ">=";
        private const string AndString = "&&";
        private const string OrString = "||";
        private Func<object, object, bool> mFunc;
    }
}
