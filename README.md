# ExpressionMocking2

purpose of this project is to show how to setup a Mock object to accept an Expression to filter a result set.

<pre><code>
filerEmailRepository
                .Setup(fr => fr.GetList(It.IsAny<Expression<Func<FilerEmail, bool>>>()))
                .Returns(new Func<Expression<Func<FilerEmail, bool>>, IQueryable<FilerEmail>>(
                 expr => testlist.AsQueryable().Where(expr.Compile()).AsQueryable()));

            var svc = new FilerEmailService(filerEmailRepository.Object);
</code></pre>
