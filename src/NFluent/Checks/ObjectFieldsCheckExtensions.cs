﻿#region File header

 // --------------------------------------------------------------------------------------------------------------------
 // <copyright file="ObjectFieldsCheckExtensions.cs" company="">
 //   Copyright 2014 Cyrille DUPUYDAUBY, Thomas PIERRAIN
 //   Licensed under the Apache License, Version 2.0 (the "License");
 //   you may not use this file except in compliance with the License.
 //   You may obtain a copy of the License at
 //       http://www.apache.org/licenses/LICENSE-2.0
 //   Unless required by applicable law or agreed to in writing, software
 //   distributed under the License is distributed on an "AS IS" BASIS,
 //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 //   See the License for the specific language governing permissions and
 //   limitations under the License.
 // </copyright>
 // --------------------------------------------------------------------------------------------------------------------

#endregion

namespace NFluent
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Reflection;
    using Extensibility;
    using Helpers;
    using Kernel;

    /// <summary>
    ///     Provides check methods to be executed on an object instance.
    /// </summary>
    public static class ObjectFieldsCheckExtensions
    {
        private const BindingFlags FlagsForFields =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;


        /// <summary>
        ///     Checks that the actual actualValue has fields equals to the expected actualValue ones.
        /// </summary>
        /// <param name="check">
        ///     The fluent check to be extended.
        /// </param>
        /// <param name="expected">
        ///     The expected actualValue.
        /// </param>
        /// <returns>
        ///     A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">
        ///     The actual actualValue doesn't have all fields equal to the expected actualValue ones.
        /// </exception>
        /// <remarks>
        ///     The comparison is done field by field.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use HasFieldsWithSameValues instead.")]
        public static ICheckLink<ICheck<object>> HasFieldsEqualToThose(this ICheck<object> check, object expected)
        {
            return HasFieldsWithSameValues(check, expected);
        }

        /// <summary>
        ///     Checks that the actual actualValue doesn't have all fields equal to the expected actualValue ones.
        /// </summary>
        /// <param name="check">
        ///     The fluent check to be extended.
        /// </param>
        /// <param name="expected">
        ///     The expected actualValue.
        /// </param>
        /// <returns>
        ///     A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">
        ///     The actual actualValue has all fields equal to the expected actualValue ones.
        /// </exception>
        /// <remarks>
        ///     The comparison is done field by field.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use HasNotFieldsWithSameValues instead.")]
        public static ICheckLink<ICheck<object>> HasFieldsNotEqualToThose(this ICheck<object> check, object expected)
        {
            return HasNotFieldsWithSameValues(check, expected);
        }

        /// <summary>
        ///     Checks that the actual actualValue has fields equals to the expected actualValue ones.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the checked actualValue.
        /// </typeparam>
        /// <typeparam name="TU">Type of the expected actualValue.</typeparam>
        /// <param name="check">
        ///     The fluent check to be extended.
        /// </param>
        /// <param name="expected">
        ///     The expected actualValue.
        /// </param>
        /// <returns>
        ///     A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">
        ///     The actual actualValue doesn't have all fields equal to the expected actualValue ones.
        /// </exception>
        /// <remarks>
        ///     The comparison is done field by field.
        /// </remarks>
        public static ICheckLink<ICheck<T>> HasFieldsWithSameValues<T, TU>(this ICheck<T> check, TU expected)
        {
            var checker = ExtensibilityHelper.ExtractChecker(check);
            var message = CheckFieldEquality(checker, checker.Value, expected, checker.Negated, FlagsForFields);

            if (message != null)
            {
                throw new FluentCheckException(message);
            }

            return checker.BuildChainingObject();
        }

        /// <summary>
        ///     Checks that the actual actualValue doesn't have all fields equal to the expected actualValue ones.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of the checked actualValue.
        /// </typeparam>
        /// <param name="check">
        ///     The fluent check to be extended.
        /// </param>
        /// <param name="expected">
        ///     The expected actualValue.
        /// </param>
        /// <returns>
        ///     A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">
        ///     The actual actualValue has all fields equal to the expected actualValue ones.
        /// </exception>
        /// <remarks>
        ///     The comparison is done field by field.
        /// </remarks>
        public static ICheckLink<ICheck<T>> HasNotFieldsWithSameValues<T>(this ICheck<T> check, object expected)
        {
            var checker = ExtensibilityHelper.ExtractChecker(check);
            var negated = !checker.Negated;

            var message = CheckFieldEquality(checker, checker.Value, expected, negated, FlagsForFields);

            if (message != null)
            {
                throw new FluentCheckException(message);
            }

            return checker.BuildChainingObject();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="check"></param>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public static  ICheck<ExtendedFieldInfo> Considering<T>(this ICheck<T> check, Criteria criteria)
        {
            var checker = ExtensibilityHelper.ExtractChecker(check);
            var fieldsWrapper = new ExtendedFieldInfo(string.Empty, typeof(T), string.Empty);
            fieldsWrapper.SetFieldValue(checker.Value);
            return new FluentCheck<ExtendedFieldInfo>(fieldsWrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="check"></param>
        /// <param name="expected"></param>
        /// <returns></returns>
        public static ICheckLink<ICheck<ExtendedFieldInfo>> IsEqualTo<TU>(this ICheck<ExtendedFieldInfo> check,
            TU expected)
        {
            var checker = ExtensibilityHelper.ExtractChecker(check);
            var expectedWrapper = new ExtendedFieldInfo(string.Empty, typeof(TU), string.Empty);
            expectedWrapper.SetFieldValue(expected);

            CompareFields(checker, false, FlagsForFields, expectedWrapper, checker.Value);
            return checker.BuildChainingObject();
        }

        /// <summary>
        /// 
        /// </summary>
        public class Criteria
        {}

        /// <summary>
        /// 
        /// </summary>
        public class Private
        {
            /// <summary>
            /// 
            /// </summary>
            public static Criteria Fields { get; private set; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static class Public
        {
            /// <summary>
            /// 
            /// </summary>
            public static Criteria Fields { get; private set; }
        }

        private static string CheckFieldEquality<T, TU>(
            IChecker<T, ICheck<T>> checker,
            T value,
            TU expected,
            bool negated,
            BindingFlags flags)
        {
            var expectedValue = new ExtendedFieldInfo(string.Empty, expected?.GetType() ?? typeof(TU), string.Empty);
            expectedValue.SetFieldValue(expected);
            var actualValue = new ExtendedFieldInfo(string.Empty, value?.GetType() ?? typeof(T), string.Empty);
            actualValue.SetFieldValue(value);

            return CompareFields(checker, negated, flags, expectedValue, actualValue);
        }

        private static string CompareFields<T>(IChecker<T, ICheck<T>> checker, bool negated, BindingFlags flags,
            ExtendedFieldInfo expectedValue, ExtendedFieldInfo actualValue)
        {
            var analysis = expectedValue.CompareValue(actualValue, new List<object>(), 1, flags);

            foreach (var fieldMatch in analysis)
            {
                var result = fieldMatch.BuildMessage(checker, negated);
                if (result != null)
                {
                    return result.ToString();
                }
            }

            return null;
        }
    }
}