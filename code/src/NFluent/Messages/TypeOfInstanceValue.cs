﻿// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="TypeOfInstanceValue.cs" company="NFluent">
//   Copyright 2019 Thomas PIERRAIN & Cyrille DUPUYDAUBY
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

namespace NFluent.Messages
{
    using System;
    using Extensions;

    internal class TypeOfInstanceValue : ISelfDescriptiveValue
    {
        private readonly Type type;

        public TypeOfInstanceValue(Type type)
        {
            this.type = type;
        }

        public string ValueDescription => $"an instance of {this}";

        public override string ToString()
        {
            return this.type == null ? "[null]" : $"[{this.type.TypeToStringProperlyFormatted()}]";
        }
    }
}