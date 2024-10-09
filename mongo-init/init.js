db.createCollection('users');
db.createCollection('products');
db.createCollection('categories');

db.products.createIndex({ "category.id": 1, created_at: -1 })

db.categories.insertMany([
    {
        "_id": ObjectId(),
        "Name": "Grocery"
    },
    {
        "_id": ObjectId(),
        "Name": "Electronics"
    },
    {
        "_id": ObjectId(),
        "Name": "Clothing"
    },
    {
        "_id": ObjectId(),
        "Name": "Books"
    }
]);
