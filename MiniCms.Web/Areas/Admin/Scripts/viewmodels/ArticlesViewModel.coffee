# @reference /scripts/knockback.js
# @reference CategoriesViewModel.js

class window.ArticlesViewModel extends kb.ViewModel
	constructor: (articles, categories) ->
		@articles = kb.collectionObservable(articles, {view_model: ArticleViewModel})
		@categories = kb.collectionObservable(categories, {view_model: CategoryViewModel})
		@checkAll = ko.observable(false)
		@selectAll = (checked) ->
			for art in @articles()
				art.selected(@checkAll() == false)
			return true

class window.ArticleViewModel extends kb.ViewModel
	constructor: (model) ->
		@date = kb.observable(model, { key: 'DatePublished', localizer: LongDateLocalizer })
		@title = kb.observable(model, { key: 'Title' })
		@slug = kb.observable(model, { key: 'Slug' })
		@commentcount = kb.observable(model, { key: 'CommentCount' })
		@tags = kb.observable(model, { key: 'Tags' })
		@author = kb.observable(model, { key: 'Author' })
		@selected = ko.observable()

LongDateLocalizer = kb.LocalizedObservable.extend({
	constructor: (value, options, view_model) ->
		kb.LocalizedObservable.prototype.constructor.apply(this, arguments)
		return kb.utils.wrappedObservable(@)
		
	read: (value) ->
		return Globalize.format(new Date(value), 'dd MMMM yyyy', kb.locale_manager.getLocale())
		
	write: (localized_string, value) ->
		new_value = Globalize.parseDate(localized_string, 'dd MMMM yyyy', kb.locale_manager.getLocale())
		
		if not (new_value and _.isDate(new_value))
			return kb.utils.wrappedObservable(this).resetToCurrent()
		
		value.setTime(new_value.valueOf())
})