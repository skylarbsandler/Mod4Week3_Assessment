# Week 3 Assessment

## Setup
* Fork and Clone this repository
* Run `update-database` - let the instructors know if you run into any issues!

## Exercise (10 Points)
### Securing the Application (4 points)
* Use Secrets Managemnt to remove the database connection string from the application.
* So that we can see the full implmentation, include a screenshot below to show your `secrets.json` file

![Screenshot 2023-09-07 091035](https://github.com/skylarbsandler/Mod4Week3_Assessment/assets/95989203/3bbafb1a-c2b5-4d1c-b596-a9c16160d40d)

### Maintaining Current-User (6 points)

This application includes some starter code so that we could maintain a current user.  Review the Login and Logout code in the Home Controller, along with the Login and Logout buttons in the Home/Index.cshtml file.  Building on this pre-existing structure:
* Create a cookie that holds a key for "currentUser" when a user logs in.
* Delete that cookie when a user logs out.
* Add the value of "current user" to all views

## Questions (10 Points)

For the following questions, answer as if you are in an interview!
1. Describe one strategy you have used to maintain state in a web application. (2 points)
  I frequently use cookies to maintain state in a web application. Cookies store small pieces of data about the user's interactions with the application. When the user revisits the application, their browser sends these cookies to the server which allows the application to maintain their session state. I have used cookies to store information about a user's preferences (such as storing favorited books) to provide a more customized user experience.
3. How would you protect sensitive data that we need to store in our database - for example, passwords? (2 points)
One strategy I have used to protect sensitive data stored in a database is by Hashing. Hashing involves transforming the passwords into meaningless strings of characters. There are a variety of hash function types that determine the function of how the passwords are transformed. I have used SHA256. However, because these hash functions follow a similar patterns (for example, SHA256 always produce hashed strings of 32 characters), it can be easy for hackers to deduce easily guess-able password patterns. For this reason, going the extra step of salting makes the password storage more secure. A salt is adding extra characters to any sensitive data before hashing. Salting results in less predictable data storage.
4. Describe 3 additional common security risks in web development. (make sure you discuss what you know about the risk, and if you know how to minimize the risk) (6 points)
-SQL Injection is a hacking technique where SQL queries are inserted into input fields of forms. This can lead to data breaches or unauthorized database access. One way to prevent this is to validate user input in forms to ensure it meets the expected format and doesn't contain malicious code.
-Overposting is when a hacker sends in more data than required in a form. This can lead to the hacker being able to change additional properties like Ids. A Data Transfer Object can be used as a layer of seperation between the form and the database by only accepting specified data.
-API Rate Limiting is used to limit the amount of requests/calls a user can make to an API in a specified time frame. This can prevent DDOS attacks and ensures equitable access for all users.
