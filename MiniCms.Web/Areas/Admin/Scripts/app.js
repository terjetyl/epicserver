(function() {
  var LocaleManager;

  LocaleManager = (function() {

    LocaleManager.name = 'LocaleManager';

    function LocaleManager(locale_identifier, translations_by_locale) {
      this.translations_by_locale = translations_by_locale;
      this.current_locale = ko.observable(locale_identifier);
    }

    LocaleManager.prototype.get = function(string_id) {
      if (!this.translations_by_locale[this.current_locale()]) {
        return '(no translation)';
      }
      if (!this.translations_by_locale[this.current_locale()].hasOwnProperty(string_id)) {
        return '(no translation)';
      }
      return this.translations_by_locale[this.current_locale()][string_id];
    };

    LocaleManager.prototype.getLocale = function() {
      return this.current_locale();
    };

    LocaleManager.prototype.setLocale = function(locale_identifier) {
      this.current_locale(locale_identifier);
      return this.trigger('change', this);
    };

    return LocaleManager;

  })();

  _.extend(LocaleManager.prototype, Backbone.Events);

  kb.locale_manager = new LocaleManager;

  kb.locale_manager.setLocale('en-US');

  kb.locale_change_observable = kb.triggeredObservable(kb.locale_manager, 'change');

}).call(this);
