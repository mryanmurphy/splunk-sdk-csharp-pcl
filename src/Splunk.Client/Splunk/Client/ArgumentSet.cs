﻿/*
 * Copyright 2014 Splunk, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"): you may
 * not use this file except in compliance with the License. You may obtain
 * a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations
 * under the License.
 */

//// TODO:
//// [O] Documentation
//// [ ] Diagnostics

namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;

    /// <summary>
    /// Provides custom arguments.
    /// </summary>
    public class ArgumentSet : ISet<Argument>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentSet"/>
        /// class.
        /// </summary>
        public ArgumentSet(string argumentPrefix = null)
        {
            this.argumentPrefix = string.IsNullOrEmpty(argumentPrefix) ? null : argumentPrefix;
            this.set = new HashSet<Argument>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArgumentSet"/>
        /// class from a collection of <see cref="Argument"/> values.
        /// </summary>
        public ArgumentSet(IEnumerable<Argument> collection, string argumentPrefix)
        {
            Contract.Requires<ArgumentNullException>(collection != null);
            
            this.argumentPrefix = string.IsNullOrEmpty(argumentPrefix) ? null : argumentPrefix;
            this.set = new HashSet<Argument>(collection);
        }

        #endregion

        #region Properties

        public string ArgumentPrefix
        {
            get { return this.argumentPrefix; }
        }

        public int Count
        { 
            get { return this.set.Count; } 
        }

        public bool IsReadOnly
        { 
            get { return false; } 
        }

        #endregion

        #region Methods

        public void Clear()
        {
            this.set.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Argument> GetEnumerator()
        {
            if (this.argumentPrefix == null)
            {
                foreach (var item in this.set)
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in this.set)
                {
                    yield return new Argument(this.argumentPrefix + item.Name, item.Value);
                }
            }
        }

        public override string ToString()
        {
            return string.Join("; ", from arg in this select arg.ToString());
        }

        public bool Add(Argument item)
        {
            return this.set.Add(item);
        }

        void ICollection<Argument>.Add(Argument item)
        {
            this.set.Add(item);
        }

        public bool Contains(Argument item)
        {
            return this.set.Contains(item);
        }

        public void CopyTo(Argument[] array, int index)
        {
            this.set.CopyTo(array, index);
        }

        public void ExceptWith(IEnumerable<Argument> other)
        {
            this.set.ExceptWith(other);
        }

        public void IntersectWith(IEnumerable<Argument> other)
        {
            this.set.IntersectWith(other);
        }

        public bool IsProperSubsetOf(IEnumerable<Argument> other)
        {
            return this.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<Argument> other)
        {
            return this.IsProperSupersetOf(other);
        }

        public bool IsSubsetOf(IEnumerable<Argument> other)
        {
            return this.set.IsSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<Argument> other)
        {
            return this.set.IsSupersetOf(other);
        }

        public bool Overlaps(IEnumerable<Argument> other)
        {
            return this.set.Overlaps(other);
        }

        public bool Remove(Argument item)
        {
            return this.set.Remove(item);
        }

        public bool SetEquals(IEnumerable<Argument> other)
        {
            return this.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<Argument> other)
        {
            this.set.SymmetricExceptWith(other);
        }

        public void UnionWith(IEnumerable<Argument> other)
        {
            this.set.UnionWith(other);
        }

        #endregion

        #region Privates

        readonly string argumentPrefix;
        readonly HashSet<Argument> set;

        #endregion
    }
}
