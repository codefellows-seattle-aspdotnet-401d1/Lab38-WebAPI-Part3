![cf](http://i.imgur.com/7v5ASc8.png) Lab38-WebAPI-Pt3
=====================================

## To Submit this Assignment
- fork this repository
- write all of your code in a directory named `lab-#`; + `<your name>` **e.g.** `lab38-amanda`
- push to your repository
- submit a pull request to this repository
- submit a link to your PR in canvas

## Directions 
- Building off of Lab 37, 
  - Add a Second resource into your application (i.e. We added lists)
  - Add the appropriate Controller and actions for your additional resource. 
  - Here is what your actions should contain:
    - Get(ALL) => Get all the lists possible
    - Get (ID) => Get the list AND it's associated IDs *See Note beneath directions*
    - POST => Create a new list
    - PUT => Update a List
    - Delete => Delete a list and all it's associated Tasks.
    
 - Write unit tests. Have a TOTAL (for your whole project) of 8 working/passing unit tests. 
-  COMMENT your code. Clearly. Identify the above requirements within your code. It is important that ALL The code written in this project is yours and you comment exaclty what/why everything is going on. 
- Use Postman to test your API.
- Deploy your application to Azure

**NOTE:** During our demo, I had put our GetTasks() call in our ListTasks model. I have updated the demo code accordingly, we will keep the database call in our Controller for this lab. it is possible to have this call in our model, except it takes a littel bit more work then what we have covered so far in the course. Traditionally it is recomended to keep these calls in the Controller. Keep database ("_context") calls to the controller. 

## ReadMe
- Your readme should include the following information:
  - Your link to your Azure deployed link
  - How long did it take you to complete this assignment? 3-4 hours
  - What did you struggle with? Why? How did you solve? I struggled with creating things to test in my unit tests folder.
  - What did you learn during this assignment? I learned that which controller and model you refer to in a test matters.
  - What resources did you utilize for this assingment? class demo, advice from instructor

## Rubric
- 2pts: Additional resources is added with all required actions/behavior
- 2pts: Unit tests present and passing
- 2pts: Deploy your application. Provide your link in your readme
- 2pts: Code is clearly commented.
- 2pt: Readme included with answers to questions
