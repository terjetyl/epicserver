# @reference /scripts/jquery-1.7.2.js
# @reference /scripts/jquery.globalize/globalize.js
# @reference /scripts/jquery.globalize/cultures/globalize.culture.en-US.js
# @reference /scripts/backbone.js
# @reference /scripts/backbone.localStorage.js
# @reference /scripts/knockback.js
# @reference models/category.coffee
# @reference models/article.coffee
# @reference viewmodels/ArticlesViewModel.coffee
# @reference viewmodels/CreateArticleViewModel.coffee
# @reference viewmodels/CategoriesViewModel.coffee

class LocaleManager
  constructor: (locale_identifier, @translations_by_locale) ->
    @current_locale = ko.observable(locale_identifier)

  get: (string_id) ->
    return '(no translation)' unless @translations_by_locale[@current_locale()]
    return '(no translation)' unless @translations_by_locale[@current_locale()].hasOwnProperty(string_id)
    return @translations_by_locale[@current_locale()][string_id]

  getLocale: -> return @current_locale()
  setLocale: (locale_identifier) ->
    @current_locale(locale_identifier)
    @trigger('change', @)

_.extend(LocaleManager.prototype, Backbone.Events)

kb.locale_manager = new LocaleManager

# EXTENSIONS: Configure localization manager
kb.locale_manager.setLocale('en-US')
kb.locale_change_observable = kb.triggeredObservable(kb.locale_manager, 'change') # use to register a localization dependency
