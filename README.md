Quoting Dojo
You are going to build a simple app that allows users to add quotes to a database and display them on a separate page.

The 'add my quote' button should add the user's quote to the database, but the 'skip to quotes' button should take the user directly to the main page.

Use the following URLs for your project:

GET ' / ' for the screen on the left.
POST '/quotes' for the method of the form to make a new quote.
GET '/quotes' for the screen on the right (where all the quotes are rendered.
When you create a new quote if there are errors with the model, you should render a view and pass errors to that view instead of redirecting. That way we won't lose our data and thereby not need to use a session variable!