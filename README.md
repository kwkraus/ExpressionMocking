# ExpressionMocking2

purpose of this project is to show how to setup a Mock object to accept an Expression to filter a result set.

<pre><code>
filerEmailRepository
                .Setup(fr => fr.GetList(It.IsAny&lt;Expression&lt;Func&lt;FilerEmail, bool&gt;&gt;&gt;()))
                .Returns(new Func&lt;Expression&lt;Func&lt;FilerEmail, bool&gt;&gt;, IQueryable&lt;FilerEmail&gt;&gt;(
                 expr => testlist.AsQueryable().Where(expr.Compile()).AsQueryable()));

var svc = new FilerEmailService(filerEmailRepository.Object);
</code></pre>
