<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="ATS_friendly_Resume_Maker.form" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .form-container {
            margin: 10px 0;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #f9f9f9;
        }
        .form-container input, .form-container select, .form-container textarea {
            margin: 5px 0;
            padding: 8px;
            width: 100%;
        }
        .form-container button {
            padding: 5px 10px;
            background-color: red;
            color: white;
            border: none;
            cursor: pointer;
        }
        .form-container button:hover {
            background-color: darkred;
        }
        label {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Add Employment, Education, Website, and Skills Form buttons -->
            <button type="button" id="addEmploymentFormButton">Add Employment</button>
            <button type="button" id="addEducationFormButton">Add Education</button>
            <button type="button" id="addWebsiteFormButton">Add Personal Website</button>
            <button type="button" id="addSkillFormButton">Add Skills</button>

            <div id="formContainer"></div>

            <!-- Submit Button -->
            <button type="button" id="submitFormButton">Submit All Forms</button>
        </div>
    </form>

    <script src="/assets/js/script.js"></script>
    <script>
        // Add event listeners to prevent page reload
        document.getElementById('addEmploymentFormButton').addEventListener('click', function () {
            addEmploymentForm();
        });

        document.getElementById('addEducationFormButton').addEventListener('click', function () {
            addEducationForm();
        });

        document.getElementById('addWebsiteFormButton').addEventListener('click', function () {
            addWebsiteForm();
        });

        document.getElementById('addSkillFormButton').addEventListener('click', function () {
            addSkillForm();
        });

        // Function to add Employment Form dynamically
        function addEmploymentForm() {
            var container = document.getElementById("formContainer");
            var form = document.createElement('div');
            form.className = 'form-container';
            form.innerHTML = `
                <label for="companyName">Company Name:</label><input type="text" id="companyName" name="companyName" required>
                <label for="title">Title:</label><input type="text" id="title" name="title" required>
                <label for="employmentType">Employment Type:</label>
                <select id="employmentType" name="employmentType">
                    <option value="full-time">Full-time</option>
                    <option value="part-time">Part-time</option>
                    <option value="freelancer">Freelancer</option>
                    <option value="self-employed">Self-employed</option>
                </select>
                <label for="startMonth">Start Month:</label><input type="month" id="startMonth" name="startMonth" required>
                <label for="endMonth">End Month:</label><input type="month" id="endMonth" name="endMonth">
                <label for="location">Location:</label><input type="text" id="location" name="location" required>
                <label for="description">Description:</label><textarea id="description" name="description" maxlength="250"></textarea>
                <button type="button" class="deleteButton">Delete</button>
            `;
            container.appendChild(form);

            // Add event listener for the delete button in this newly added form
            form.querySelector('.deleteButton').addEventListener('click', function () {
                container.removeChild(form); // Delete the form
            });
        }

        // Function to add Education Form dynamically
        function addEducationForm() {
            var container = document.getElementById("formContainer");
            var form = document.createElement('div');
            form.className = 'form-container';
            form.innerHTML = `
                <label for="schoolName">School Name:</label><input type="text" id="schoolName" name="schoolName" required>
                <label for="degree">Degree:</label><input type="text" id="degree" name="degree" required>
                <label for="startYear">Start Year:</label><input type="number" id="startYear" name="startYear" required min="1900" max="2099">
                <label for="endYear">End Year:</label><input type="number" id="endYear" name="endYear" min="1900" max="2099">
                <label for="city">City:</label><input type="text" id="city" name="city" required>
                <label for="eduDescription">Description:</label><textarea id="eduDescription" name="eduDescription" maxlength="250"></textarea>
                <button type="button" class="deleteButton">Delete</button>
            `;
            container.appendChild(form);

            // Add event listener for the delete button in this newly added form
            form.querySelector('.deleteButton').addEventListener('click', function () {
                container.removeChild(form); // Delete the form
            });
        }

        // Function to add Website Form dynamically
        function addWebsiteForm() {
            var container = document.getElementById("formContainer");
            var form = document.createElement('div');
            form.className = 'form-container';
            form.innerHTML = `
                <label for="websiteLabel">Label:</label><input type="text" id="websiteLabel" name="websiteLabel" required>
                <label for="websiteUrl">URL:</label><input type="url" id="websiteUrl" name="websiteUrl" required>
                <button type="button" class="deleteButton">Delete</button>
            `;
            container.appendChild(form);

            // Add event listener for the delete button in this newly added form
            form.querySelector('.deleteButton').addEventListener('click', function () {
                container.removeChild(form); // Delete the form
            });
        }

        // Function to add Skill Form dynamically
        function addSkillForm() {
            var container = document.getElementById("formContainer");
            var form = document.createElement('div');
            form.className = 'form-container';
            form.innerHTML = `
                <label for="skills">Skills (separate by commas):</label><input type="text" id="skills" name="skills" required>
                <button type="button" class="deleteButton">Delete</button>
            `;
            container.appendChild(form);

            // Add event listener for the delete button in this newly added form
            form.querySelector('.deleteButton').addEventListener('click', function () {
                container.removeChild(form); // Delete the form
            });
        }

        // Add event listener to submit button to collect form data (customize as per your needs)
        document.getElementById('submitFormButton').addEventListener('click', function () {
            // Collect all data and handle submission logic (e.g., use AJAX or hidden fields to send to the server)
            alert('Submit logic should be here.');
        });
    </script>
</body>
</html>
