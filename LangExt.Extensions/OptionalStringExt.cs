using LanguageExt;
using static LanguageExt.Prelude;

namespace LangExt.Extensions
{
    public static class OptionalStringExt
    {
        public static Option<string> EmptyAsNone1(this string source)
            => source.Apply(Optional)
                .Match(
                    x => string.IsNullOrEmpty(x)
                        ? Option<string>.None
                        : Some(x),
                    () => Option<string>.None
                );

        public static Option<string> EmptyAsNone2(this string source) =>
            source
                .Apply(Optional)
                .Filter(x => !string.IsNullOrEmpty(x));

        public static Option<string> EmptyAsNone(this string source) =>
            source
                .Apply(Optional)
                .EmptyAsNone();

        public static Option<string> EmptyAsNone(this Option<string> optStr) =>
            optStr
                .Filter(x => x != string.Empty);
    }
}