﻿
//
//  Copyright 2018  AppRopio
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
using System;
using AppRopio.Base.Droid.Views;
using AppRopio.Base.Settings.Core;
using AppRopio.Base.Settings.Core.ViewModels.Languages;
namespace AppRopio.Base.Settings.Droid.Views.Languages
{
    public class LanguagesFragment : CommonFragment<ILanguagesViewModel>
    {
        public LanguagesFragment()
            : base (Resource.Layout.app_settings_languages)
        {
            Title = LocalizationService.GetLocalizableString(SettingsConstants.RESX_NAME, "Languages_Title");
        }
    }
}