# 🏪 Inventory Management System (C# Console App)

A simple yet powerful **CRUD Inventory Management System** built with **C#**, designed to manage products in a clean and colorful **Console Interface** 🎨.  
Users can **Add**, **View**, **Update**, and **Remove** products — all while data is saved and loaded automatically from a CSV file.

---

## 🚀 Features

✅ **Add Products** — Easily add new products with name, quantity, and price  
✅ **View Products** — Display all products in a neatly formatted table  
✅ **Update Products** — Modify product details (name, quantity, price, or all at once)  
✅ **Remove Products** — Delete any product from the list  
✅ **Persistent Data** — Products are saved in a CSV file for future sessions  
✅ **Colorful Console** — Each message, menu, and alert is displayed with attractive colors for a better experience 🌈  

---

## 🧠 How It Works

1. The app starts with a main menu offering CRUD options  
2. Each product has:
   - 🆔 **ID**
   - 🏷️ **Name**
   - 📦 **Quantity**
   - 💰 **Price**
3. All data is saved in a file named **Products.csv**  
4. The program reads and loads existing data automatically at startup (if the file exists)  
5. Color-coded messages guide the user through every action (success, error, info, etc.)

---

## 🧾 Example of Saved Data (`Products.csv`)

```csv
ID,Name,Quantity,Price
0,Keyboard,10,250
1,Mouse,15,100
2,Monitor,5,1200
```

🛠️ Tech Stack

Language: C# (.NET 9.0)

Data Storage: CSV File

Type: Console Application

Paradigm: Object-Oriented Programming (OOP)


🖥️ How to Run

Clone the repository:

git clone https://github.com/BahaaElsheikh/InventoryManagment.git


Open the project in Visual Studio or VS Code

Build and Run the app (Press Ctrl + F5 or click Run)

Start managing your inventory! 🚀


🎨 Console Preview (Example)

========== Welcome To Products Manager =========

========== Main Menu =========
1=> Add Product
2=> View All Products
3=> Update Product
4=> Remove Product
5=> Exit
==============================
Enter a Number from 1-5 :



✅ Messages appear in color-coded style:

🟢 Green → Success messages

🔴 Red → Errors

🟡 Yellow / Cyan → Info & prompts

💡 Future Improvements

Add CSV auto-loading on startup

Include product search by name or price range

Export data to JSON or XML

Add sorting and filtering features

👨‍💻 Author

Bahaa Elsheikh
💼 GitHub: BahaaElsheikh

📧 Email: youremail@example.com



![Language](https://img.shields.io/badge/Language-C%23-blue)
![Platform](https://img.shields.io/badge/Platform-.NET%209.0-purple)
![Type](https://img.shields.io/badge/AppType-Console-lightgrey)
