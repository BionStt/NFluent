﻿// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ICheckForExtensibility.cs" company="">
// //   Copyright 2013 Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
namespace NFluent
{
    /// <summary>
    /// Fluent check which exposes more information for extensibility purpose.
    /// </summary>
    /// <typeparam name="T">Type of the value to assert on.</typeparam>
    public interface ICheckForExtensibility<out T> : IWithValue<T>, IExposingRunnableCheck<T>, INegated, IMustImplementIForkableCheckWithoutDisplayingItsMethodsWithinIntelliSense
    {
    }
}