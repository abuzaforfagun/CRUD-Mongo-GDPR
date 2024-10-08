db = db.getSiblingDB('secure-privacy');
db.createCollection('users');
db.createCollection('products');

db.products.createIndex({ category: 1, created_at: -1 })