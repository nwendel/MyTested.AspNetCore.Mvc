﻿namespace MyTested.AspNetCore.Mvc.Test.BuildersTests.AttributesTests
{
    using Exceptions;
    using Setups;
    using Setups.Controllers;
    using Xunit;

    public class ActionAttributesTestBuilderTests
    {
        [Fact]
        public void ValidatingAntiForgeryTokenShouldNotThrowExceptionWithTheAttribute()
        {
            MyController<MvcController>
                .Instance()
                .Calling(c => c.AntiForgeryToken())
                .ShouldHave()
                .ActionAttributes(attributes => attributes.ValidatingAntiForgeryToken());
        }

        [Fact]
        public void ValidatingAntiForgeryTokenShouldThrowExceptionWithActionWithoutTheAttribute()
        {
            Test.AssertException<AttributeAssertionException>(
                () =>
                {
                    MyController<MvcController>
                        .Instance()
                        .Calling(c => c.NormalActionWithAttributes())
                        .ShouldHave()
                        .ActionAttributes(attributes => attributes.ValidatingAntiForgeryToken());
                },
                "When calling NormalActionWithAttributes action in MvcController expected action to have ValidateAntiForgeryTokenAttribute, but in fact such was not found.");
        }

    }
}
