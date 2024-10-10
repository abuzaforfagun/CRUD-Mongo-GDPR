db.createCollection('users');
db.users.insertMany([
    {
        "_id": ObjectId(),
        "Name": "Abu Zafor Fagun",
        "Email": "mdabuzaforfagun@gmail.com",
        "PhoneNumber": "+8801677813190",
        "CPRNumber": "f8fTSzULwf0uc0fRFIJdmA==",
        "Password": "e4ac5224fac6442a4e8749cf682782d256988b350ccf4b2b396bcfb9ebce81c4",
        "CreatedAt": new Date()
    }
])

db.createCollection('categories');
db.products.createIndex({ "Categories.Id": 1, CreatedAt: -1 })

db.categories.insertMany([
    {
        "_id": ObjectId("67066849e37b300a1208d7aa"),
        "Name": "Grocery"
    },
    {
        "_id": ObjectId("67066849e37b300a1208d7ab"),
        "Name": "Electronics"
    },
    {
        "_id": ObjectId("67066849e37b300a1208d7ac"),
        "Name": "Clothing"
    },
    {
        "_id": ObjectId("67066849e37b300a1208d7ad"),
        "Name": "Books"
    }
]);

db.createCollection('products');
db.products.insertMany([
    {
        "_id": ObjectId(),
        "Name": "CK T-Shirt",
        "Description": "Comfortable t shirt",
        "Price": 10.5,
        "Categories": [
            {
                "_id": "67066849e37b300a1208d7ac",
                "Name": "Clothing"
            }
        ],
        "CreatedAt": new Date()
    },
    {
        "_id": ObjectId(),
        "Name": "US Polo T-Shirt",
        "Description": "Fashionable t shirt",
        "Price": 12.5,
        "Categories": [
            {
                "_id": "67066849e37b300a1208d7ac",
                "Name": "Clothing"
            }
        ],
        "CreatedAt": new Date()
    },
    {
        "_id": ObjectId(),
        "Name": "iPhone 16 Pro max",
        "Description": "",
        "Price": 1200,
        "Categories": [
            {
                "_id": "67066849e37b300a1208d7ab",
                "Name": "Electronics"
            }
        ],
        "CreatedAt": new Date()
    },
    {
        "_id": ObjectId(),
        "Name": "Samsang S23",
        "Description": "",
        "Price": 1100,
        "Categories": [
            {
                "_id": "67066849e37b300a1208d7ab",
                "Name": "Electronics"
            }
        ],
        "CreatedAt": new Date()
    }
])