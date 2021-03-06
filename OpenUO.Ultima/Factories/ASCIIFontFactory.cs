﻿#region License Header

// /***************************************************************************
//  *   Copyright (c) 2011 OpenUO Software Team.
//  *   All Right Reserved.
//  *
//  *   AsciiFontFactory.cs
//  *
//  *   This program is free software; you can redistribute it and/or modify
//  *   it under the terms of the GNU General Public License as published by
//  *   the Free Software Foundation; either version 3 of the License, or
//  *   (at your option) any later version.
//  ***************************************************************************/

#endregion

#region Usings

using System.Threading.Tasks;

using OpenUO.Core.Patterns;
using OpenUO.Ultima.Adapters;

#endregion

namespace OpenUO.Ultima
{
    public class ASCIIFontFactory : AdapterFactoryBase
    {
        public ASCIIFontFactory(InstallLocation install, IContainer container)
            : base(install, container)
        {
        }

        public T GetText<T>(int fontId, string text, short hueId)
        {
            return GetAdapter<IASCIIFontStorageAdapter<T>>().GetText(fontId, text, hueId);
        }

        public Task<T> GetTextAsync<T>(int fontId, string text, short hueId)
        {
            return Task.Run(async () =>
            {
                var adapter = await GetAdapterAsync<IASCIIFontStorageAdapter<T>>().ConfigureAwait(false);

                return await adapter.GetTextAsync(fontId, text, hueId).ConfigureAwait(false);
            });
        }
    }
}