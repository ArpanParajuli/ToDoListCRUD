# ToDoList Backend Project


#  testing APIs

GET /api/task 

{
    "UserId" : 1
}




POST /api/task/add

{
    "UserId" : 1,
    "Name" : "Reading books",
    "Description" : "Reading book 10 page per day"
}




DELETE /api/task/remove


{
        "UserId" : 1
}


PATCH /api/task/update/ (Haven't added)




POST /api/authuser/login

{
    "email" : "arpandev12@gmail.com",
    "password": "arpandev12@"
}


POST /api/authuser/register


{
    "name" : "arpandev12",
    "email" : "arpandev12@gmail.com",
    "password": "arpandev12@"
}



# Other improvement will be in next push update

- Added JWT auth