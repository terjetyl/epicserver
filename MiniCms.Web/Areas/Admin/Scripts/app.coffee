# @reference /scripts/jquery-1.7.2.js
# @reference /scripts/backbone.js
# @reference /scripts/backbone.localStorage.js
# @reference models/category.coffee
# @reference models/article.coffee
# @reference viewmodels/ArticlesViewModel.coffee
# @reference viewmodels/CreateArticleViewModel.coffee
# @reference viewmodels/CategoriesViewModel.coffee

window.addcategory = (name) ->
	category = { Name: name }
	$.ajax '/api/categories',
		type: 'POST'
		data: JSON.stringify(category)
		dataType: 'json'
		contentType: "application/json"
		error: (jqXHR, textStatus, errorThrown) ->
			$('body').append "AJAX Error: #{textStatus}"
		success: (data, textStatus, jqXHR) ->
			$('body').append "Successful AJAX call: #{data}"

window.getcategories = (callback) ->
	$.ajax '/api/categories',
		type: 'GET'
		contentType: "application/json"
		dataType: 'json'
		error: (jqXHR, textStatus, errorThrown) ->
			console.log "AJAX Error: #{textStatus}"
		success: (data, textStatus, jqXHR) ->
			callback(data)

window.loadarticles = () ->
	articles = new Articles