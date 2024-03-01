Test task for C# Developer - Templater

You need to build a library that will be able to generate HTML based on template and JSON data. The 
library should have one simple method:
public string CreateHtml(string template, string jsonData);
Then implement a console application that allows sending two files to your library and saves output as a 
file. Console application parameters:
- templateFilePath
- dataFilePath
- outputFilePath

Check the example below. There is JSON data, template HTML and desired result HTML.

Json data:

{
"products": [
{
"name": "Apple",
"price": 329,
"description": "flat-out fun"
},
{
"name": "Orange",
"price": 25,
"description": "colorful"
},
{
"name": "Banana",
"price": 99,
"description": "peel it"
}
]
}

Template HTML:

<ul id="products">
 {% for product in products %}
 <li>
 <h2>{{product.name}}</h2>
 Only {{product.price | price }}
 {{product.description | paragraph }}
 </li>
 {% endfor %}
</ul>

Result HTML:

<ul id="products">
 <li>
 <h2>Apple</h2>
 Only $329
 flat-out fun
 </li>
 <li>
 <h2>Orange</h2>
 Only $25
 colorful 
 </li>
 <li>
 <h2>Banana</h2>
 Only $99
 peel it
 </li>
</ul>

Things to consider
• The `<li>` tags are at the same index as in the template, even though the `{% for }` tag had some 
leading spaces 
• The `<ul>` and `<li>` tags are on contiguous lines even though the `{% for }` is taking a full line.
• The task is intended to check your knowledge and programming skills. Please note that if you 
managed to make things work, it wouldn't automatically mean successful task completion. We 
will evaluate your architectural skills, programming style, and knowledge of performance 
optimization.

Technologies
C#, .NET

Deadline
There are no strict deadlines. We understand that you may be working on another job. It would be great 
if you could complete it within a week.

Send results
Publish your code to the GIT repository. Don’t use any “Plumsail” related words in the repository to 
prevent other candidates from finding your implementation and taking credit for it.
In the Readme file briefly describe your choices of architecture for this task. 
Send your solution to recruitment@plumsail.com

Note: Please add a link to your HeadHunter resume and your full name as in your CV. Otherwise, it may 
be tricky to match your email and communication in HeadHunter chat. 
