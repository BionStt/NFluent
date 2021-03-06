﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionAttribute.cs" company="">
//   Copyright 2017 Cyrille DUPUYDAUBY
//     Licensed under the Apache License, Version 2.0 (the "License");
//     you may not use this file except in compliance with the License.
//     You may obtain a copy of the License at
//         http://www.apache.org/licenses/LICENSE-2.0
//     Unless required by applicable law or agreed to in writing, software
//     distributed under the License is distributed on an "AS IS" BASIS,
//     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//     See the License for the specific language governing permissions and
//     limitations under the License.
// </copyright>

namespace System.Runtime.CompilerServices
{
#if DOTNET_30 || DOTNET_20
    /// <summary>
    /// This declaration enables the support of extension methods for Net 2.0 and 3.0.
    /// </summary>
    internal class ExtensionAttribute : Attribute { }
#endif
}