// Generated by CoffeeScript 1.3.3

/*
knockback-inspector.js 0.1.0
(c) 2012 Kevin Malakoff.
Knockback-Inspector.js is freely distributable under the MIT license.
See the following for full license details:
  https://github.com/kmalakoff/knockback-inspector/blob/master/LICENSE
Dependencies: Knockout.js, Underscore.js, Backbone.js, and Knockback.js.
*/


(function() {
  var __hasProp = {}.hasOwnProperty,
    __extends = function(child, parent) { for (var key in parent) { if (__hasProp.call(parent, key)) child[key] = parent[key]; } function ctor() { this.constructor = child; } ctor.prototype = parent.prototype; child.prototype = new ctor(); child.__super__ = parent.prototype; return child; };

  this.kbi || (this.kbi = {});

  this.kbi.VERSION = '0.1.0';

  kbi.StringTemplateSource = (function() {

    function StringTemplateSource(template_string) {
      this.template_string = template_string;
    }

    StringTemplateSource.prototype.text = function(value) {
      return this.template_string;
    };

    return StringTemplateSource;

  })();

  kbi.StringTemplateEngine = (function(_super) {

    __extends(StringTemplateEngine, _super);

    function StringTemplateEngine() {
      this.allowTemplateRewriting = false;
    }

    StringTemplateEngine.prototype.makeTemplateSource = function(template) {
      switch (template) {
        case 'kbi_model_node':
          return new kbi.StringTemplateSource(kbi.ModelNodeView);
        case 'kbi_collection_node':
          return new kbi.StringTemplateSource(kbi.CollectionNodeView);
        default:
          return ko.nativeTemplateEngine.prototype.makeTemplateSource.apply(this, arguments);
      }
    };

    return StringTemplateEngine;

  })(ko.nativeTemplateEngine);

  kbi.FetchedModel = (function(_super) {

    __extends(FetchedModel, _super);

    function FetchedModel() {
      return FetchedModel.__super__.constructor.apply(this, arguments);
    }

    FetchedModel.prototype.parse = function(response) {
      var attributes, collection, key, model, value;
      attributes = {};
      for (key in response) {
        value = response[key];
        if (_.isObject(value)) {
          model = new kbi.FetchedModel();
          attributes[key] = model.set(model.parse(value));
        } else if (_.isArray(value)) {
          collection = new kbi.FetchedCollection();
          attributes[key] = collection.reset(collection.parse(value));
        } else {
          attributes[key] = value;
        }
      }
      return attributes;
    };

    return FetchedModel;

  })(Backbone.Model);

  kbi.FetchedCollection = (function(_super) {

    __extends(FetchedCollection, _super);

    function FetchedCollection() {
      return FetchedCollection.__super__.constructor.apply(this, arguments);
    }

    FetchedCollection.prototype.model = kbi.FetchedModel;

    FetchedCollection.prototype.parse = function(response) {
      return _.map(response.results, function(result) {
        var model;
        model = new kbi.FetchedModel();
        return model.set(model.parse(result));
      });
    };

    return FetchedCollection;

  })(Backbone.Collection);

  kbi.NodeViewModel = (function() {

    function NodeViewModel(name, opened, node) {
      var model;
      this.name = name;
      this.opened = ko.observable(opened);
      this.node = ko.utils.unwrapObservable(node);
      if (this.node instanceof kb.ViewModel) {
        model = kb.utils.wrappedModel(this.node);
        this.attribute_names = ko.observableArray(model ? _.keys(model.attributes) : []);
      }
      this;

    }

    NodeViewModel.prototype.attributeType = function(key) {
      var attribute_connector;
      attribute_connector = this.node[key];
      if (ko.utils.unwrapObservable(attribute_connector) instanceof kb.ViewModel) {
        return 'model';
      }
      if (kb.utils.observableInstanceOf(attribute_connector, kb.CollectionAttributeConnector)) {
        return 'collection';
      }
      return 'simple';
    };

    return NodeViewModel;

  })();

  kbi.nodeViewModel = kbi.nvm = function(name, opened, node) {
    return new kbi.NodeViewModel(name, opened, node);
  };

  kbi.CollectionNodeView = "<li class='kbi' data-bind=\"css: {opened: opened, closed: !opened()}\">\n  <div class='collection' data-bind=\"click: function(){ opened(!opened()) }\">\n    <span data-bind=\"text: (opened() ? '- ' : '+ ' )\"></span>\n    <span data-bind=\"text: name\"></span>\n  </div>\n\n  <!-- ko if: opened -->\n    <!-- ko foreach: node -->\n      <ul class='kbi' data-bind=\"template: {name: 'kbi_model_node', data: kbi.nvm('['+$index()+']', false, $data)}\"></ul>\n    <!-- /ko -->\n  <!-- /ko -->\n</li>";

  kbi.ModelNodeView = "<li class='kbi' data-bind=\"css: {opened: opened, closed: !opened()}\">\n  <div class='kbi model' data-bind=\"click: function(){ opened(!opened()); }\">\n    <span data-bind=\"text: (opened() ? '- ' : '+ ' )\"></span>\n    <span data-bind=\"text: name\"></span>\n  </div>\n\n  <!-- ko if: opened -->\n    <!-- ko foreach: attribute_names -->\n\n      <!-- ko if: ($parent.attributeType($data) == 'simple') -->\n        <fieldset class='kbi'>\n          <label data-bind=\"text: $data\"> </label>\n          <input type='text' data-bind=\"value: $parent.node[$data]\">\n        </fieldset>\n      <!-- /ko -->\n\n      <!-- ko if: ($parent.attributeType($data) == 'model') -->\n        <ul class='kbi' data-bind=\"template: {name: 'kbi_model_node', data: kbi.nvm($data, false, $parent.node[$data])}\"></ul>\n      <!-- /ko -->\n\n      <!-- ko if: ($parent.attributeType($data) == 'collection') -->\n        <ul class='kbi' data-bind=\"template: {name: 'kbi_collection_node', data: kbi.nvm($data+'[]', true, $parent.node[$data])}\"></ul>\n      <!-- /ko -->\n\n    <!-- /ko -->\n  <!-- /ko -->\n</li>";

}).call(this);