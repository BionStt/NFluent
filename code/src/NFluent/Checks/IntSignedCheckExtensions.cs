﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntSignedCheckExtensions.cs" company="">
//   Copyright 2013 Thomas PIERRAIN
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

namespace NFluent
{
    using System;
    using Kernel;

    /// <summary>
    /// Provides check methods to be executed on an <see cref="int"/> value that is considered as a signed number.
    /// </summary>
    public static class IntSignedCheckExtensions
    {
        // DoNotChangeOrRemoveThisLine

        // Since this class is the model/template for the generation of all the other numbers related CheckExtensions classes, don't forget to re-generate all the other classes every time you change this one. To do that, just save the ..\T4\NumberFluentAssertionGenerator.tt file within Visual Studio. This will trigger the T4 code generation process.

        /// <summary>
        /// Checks that the actual value is strictly positive.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not strictly positive.</exception>
        [Obsolete("Use IsStrictlyPositive instead.")]
        public static ICheckLink<ICheck<int>> IsPositive(this ICheck<int> check)
        {
            return new NumberCheck<int>(check).IsStrictlyPositive();
        }

        /// <summary>
        /// Checks that the actual value is strictly positive.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not strictly positive.</exception>
        public static ICheckLink<ICheck<int>> IsStrictlyPositive(this ICheck<int> check)
        {
            return new NumberCheck<int>(check).IsStrictlyPositive();
        }

        /// <summary>
        /// Checks that the actual value is positive or equal to zero.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not positive or equal to zero.</exception>
        public static ICheckLink<ICheck<int>> IsPositiveOrZero(this ICheck<int> check)
        {
            return new NumberCheck<int>(check).IsPositiveOrZero();
        }

        /// <summary>
        /// Checks that the actual value is strictly negative.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not strictly negative.</exception>
        [Obsolete("Use IsStrictlyNegative instead.")]
        public static ICheckLink<ICheck<int>> IsNegative(this ICheck<int> check)
        {
            return new NumberCheck<int>(check).IsStrictlyNegative();
        }

        /// <summary>
        /// Checks that the actual value is strictly negative.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not strictly negative.</exception>
        public static ICheckLink<ICheck<int>> IsStrictlyNegative(this ICheck<int> check)
        {
            return new NumberCheck<int>(check).IsStrictlyNegative();
        }

        /// <summary>
        /// Checks that the actual value is negative or equal to zero.
        /// </summary>
        /// <param name="check">The fluent check to be extended.</param>
        /// <returns>
        /// A check link.
        /// </returns>
        /// <exception cref="FluentCheckException">The value is not negative or equal to zero.</exception>
        public static ICheckLink<ICheck<int>> IsNegativeOrZero(this ICheck<int> check)
        {
            return new NumberCheck<int>(check).IsNegativeOrZero();
        }

    }
}
