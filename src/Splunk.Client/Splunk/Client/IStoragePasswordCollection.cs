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

//// TODO
//// [X] Contracts - there are none
//// [O] Documentation

namespace Splunk.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Threading.Tasks;

    [ContractClass(typeof(IStoragePasswordCollectionContract<>))]
    public interface IStoragePasswordCollection<TStoragePassword> : IPaginated, IEntityCollection<TStoragePassword, Resource>
        where TStoragePassword : BaseEntity<Resource>, IStoragePassword, new()
    {
        /// <summary>
        /// Asynchronously creates a new <see cref="StoragePassword"/>.
        /// </summary>
        /// <param name="password">
        /// Password to be stored.
        /// </param>
        /// <param name="username">
        /// The username associated with the password to be stored.
        /// </param>
        /// <param name="realm">
        /// Optional domain or realm name associated with the password to be stored.
        /// </param>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/JgyIeN">POST 
        /// storage/passwords</a> endpoint to create a <see cref=
        /// "StoragePassword"/> identified by <paramref name="name"/> and
        /// <paramref name="realm"/>.
        /// </remarks>
        Task<TStoragePassword> CreateAsync(string password, string username, string realm = null);

        /// <summary>
        /// Asynchronously retrieves a <see cref="StoragePassword"/>.
        /// </summary>
        /// <param name="username">
        /// The username associated with the password to be retrieved.
        /// </param>
        /// <param name="realm">
        /// Optional domain or realm name associated with the password to be retrieved.
        /// </param>
        /// <returns>
        /// An object representing the storage password retrieved.
        /// </returns>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/HL3c0T">GET 
        /// storage/passwords/{name}</a> endpoint to retrieve the <see cref=
        /// "StoragePassword"/> identified by <paramref name="username"/> and
        /// <paramref name="realm"/>.
        /// </remarks>
        Task<TStoragePassword> GetAsync(string username, string realm = null);

        /// <summary>
        /// Asynchronously retrieves a <see cref="StoragePassword"/>.
        /// </summary>
        /// <param name="username">
        /// The username associated with the password to be retrieved.
        /// </param>
        /// <param name="realm">
        /// Optional domain or realm name associated with the password to be retrieved.
        /// </param>
        /// <returns>
        /// An object representing the storage password retrieved or <c>null</c>, if no such storage password exists.
        /// </returns>
        /// <remarks>
        /// This method uses the <a href="http://goo.gl/HL3c0T">GET 
        /// storage/passwords/{name}</a> endpoint to retrieve the <see cref=
        /// "StoragePassword"/> identified by <paramref name="username"/> and
        /// <paramref name="realm"/>.
        /// </remarks>
        Task<TStoragePassword> GetOrNullAsync(string username, string realm = null);

        /// <summary>
        /// Asynchronously retrieves select storage passwords from Splunk.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the operation. 
        /// </returns>
        /// <param name="criteria">
        /// Specifies the criteria used in selecting storage passwords.
        /// </param>
        Task GetSliceAsync(StoragePasswordCollection.Filter criteria);
    }

    [ContractClassFor(typeof(IStoragePasswordCollection<>))]
    abstract class IStoragePasswordCollectionContract<TStoragePassword> : IStoragePasswordCollection<TStoragePassword>
        where TStoragePassword : BaseEntity<Resource>, IStoragePassword, new()
    {
        public abstract TStoragePassword this[int index] { get; }
        public abstract int Count { get; }
        public abstract IReadOnlyList<Message> Messages { get; }
        public abstract Pagination Pagination { get; }

        public Task<TStoragePassword> CreateAsync(string password, string username, string realm)
        {
            Contract.Requires<ArgumentException>(password != null);
            Contract.Requires<ArgumentException>(username != null);
            return default(Task<TStoragePassword>);
        }

        public abstract Task GetAllAsync();

        public abstract Task<TStoragePassword> GetAsync(string name);

        public Task<TStoragePassword> GetAsync(string username, string realm)
        {
            Contract.Requires<ArgumentNullException>(username != null);
            return default(Task<TStoragePassword>);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return default(IEnumerator);
        }

        public abstract IEnumerator<TStoragePassword> GetEnumerator();

        public Task<TStoragePassword> GetOrNullAsync(string username, string realm)
        {
            Contract.Requires<ArgumentNullException>(username != null);
            return default(Task<TStoragePassword>);
        }

        public abstract Task GetSliceAsync(params Argument[] arguments);

        public abstract Task GetSliceAsync(IEnumerable<Argument> arguments);

        public Task GetSliceAsync(StoragePasswordCollection.Filter criteria)
        {
            Contract.Requires<ArgumentException>(criteria != null);
            return default(Task);
        }
        
        public abstract Task ReloadAsync();
    }
}
