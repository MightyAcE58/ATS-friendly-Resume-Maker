// Function to add Employment Form
//document.getElementById('addEmploymentFormButton').addEventListener('click', function () {
//    const newForm = document.createElement('div');
//    newForm.classList.add('form-container');

//    // Company Name input
//    const companyLabel = document.createElement('label');
//    companyLabel.textContent = 'Company Name:';
//    const companyNameInput = document.createElement('input');
//    companyNameInput.type = 'text';
//    companyNameInput.placeholder = 'Enter company name';

//    // Job Title input
//    const titleLabel = document.createElement('label');
//    titleLabel.textContent = 'Job Title:';
//    const titleInput = document.createElement('input');
//    titleInput.type = 'text';
//    titleInput.placeholder = 'Enter job title';

//    // Employment Type dropdown
//    const employmentLabel = document.createElement('label');
//    employmentLabel.textContent = 'Employment Type:';
//    const employmentSelect = document.createElement('select');
//    const employmentOptions = ['Full Time', 'Part Time', 'Freelancer', 'Self Employed'];
//    employmentOptions.forEach(option => {
//        const opt = document.createElement('option');
//        opt.value = option;
//        opt.textContent = option;
//        employmentSelect.appendChild(opt);
//    });

//    // Start Date (Month and Year)
//    // Start Date
//    const startLabel = document.createElement('label');
//    startLabel.textContent = 'Start Date:';
//    const startDateInput = document.createElement('input');
//    startDateInput.type = 'month'; // Use month input to combine month and year
//    startDateInput.name = 'startDate';  // optional: name attribute
//    startDateInput.required = true; // optional: required field

//    // End Date
//    const endLabel = document.createElement('label');
//    endLabel.textContent = 'End Date:';
//    const endDateInput = document.createElement('input');
//    endDateInput.type = 'month'; // Use month input to combine month and year
//    endDateInput.name = 'endDate'; // optional: name attribute
//    endDateInput.required = false; // optional: make it non-required if optional field

//    // Location input
//    const locationLabel = document.createElement('label');
//    locationLabel.textContent = 'Location:';
//    const locationInput = document.createElement('input');
//    locationInput.type = 'text';
//    locationInput.placeholder = 'Enter location';

//    // Description textarea with max 250 characters
//    const descriptionLabel = document.createElement('label');
//    descriptionLabel.textContent = 'Description (max 250 characters):';
//    const descriptionTextarea = document.createElement('textarea');
//    descriptionTextarea.maxLength = 250;
//    descriptionTextarea.placeholder = 'Enter description';
//    descriptionTextarea.rows = 4;

//    // Remove button
//    const removeButton = document.createElement('button');
//    removeButton.textContent = 'Delete';
//    removeButton.addEventListener('click', function () {
//        newForm.remove();
//    });

//    // Append all elements to the form container
//    newForm.appendChild(companyLabel);
//    newForm.appendChild(companyNameInput);
//    newForm.appendChild(titleLabel);
//    newForm.appendChild(titleInput);
//    newForm.appendChild(employmentLabel);
//    newForm.appendChild(employmentSelect);
//    newForm.appendChild(startLabel);
//    newForm.appendChild(startMonthSelect);
//    newForm.appendChild(startYearSelect);
//    newForm.appendChild(endLabel);
//    newForm.appendChild(endMonthSelect);
//    newForm.appendChild(endYearSelect);
//    newForm.appendChild(locationLabel);
//    newForm.appendChild(locationInput);
//    newForm.appendChild(descriptionLabel);
//    newForm.appendChild(descriptionTextarea);
//    newForm.appendChild(removeButton);

//    // Append the new form to the container
//    document.getElementById('formContainer').appendChild(newForm);
//});

// Function to add Education Form
document.getElementById('addEmploymentFormButton').addEventListener('click', function () {
    const newForm = document.createElement('div');
    newForm.classList.add('form-container');

    // Create Company Name input
    const companyLabel = document.createElement('label');
    companyLabel.textContent = 'Company Name:';
    const companyNameInput = document.createElement('input');
    companyNameInput.type = 'text';
    companyNameInput.placeholder = 'Enter company name';

    // Create Job Title input
    const titleLabel = document.createElement('label');
    titleLabel.textContent = 'Job Title:';
    const titleInput = document.createElement('input');
    titleInput.type = 'text';
    titleInput.placeholder = 'Enter job title';

    // Create Employment Type dropdown
    const employmentLabel = document.createElement('label');
    employmentLabel.textContent = 'Employment Type:';
    const employmentSelect = document.createElement('select');
    const employmentOptions = ['Full Time', 'Part Time', 'Freelancer', 'Self Employed'];
    employmentOptions.forEach(option => {
        const opt = document.createElement('option');
        opt.value = option;
        opt.textContent = option;
        employmentSelect.appendChild(opt);
    });

    // Start Date (Month and Year)
    const startLabel = document.createElement('label');
    startLabel.textContent = 'Start Date:';

    const startMonthSelect = document.createElement('select');
    const months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];
    months.forEach((month, index) => {
        const option = document.createElement('option');
        option.value = index + 1;  // Store month as a number (1-12)
        option.textContent = month;
        startMonthSelect.appendChild(option);
    });

    const startYearSelect = document.createElement('select');
    const startYearRange = 1990;
    const currentYear = new Date().getFullYear();
    for (let year = startYearRange; year <= currentYear; year++) {
        const option = document.createElement('option');
        option.value = year;
        option.textContent = year;
        startYearSelect.appendChild(option);
    }

    // End Date (Month and Year)
    const endLabel = document.createElement('label');
    endLabel.textContent = 'End Date:';

    const endMonthSelect = document.createElement('select');
    months.forEach((month, index) => {
        const option = document.createElement('option');
        option.value = index + 1;  // Store month as a number (1-12)
        option.textContent = month;
        endMonthSelect.appendChild(option);
    });

    const endYearSelect = document.createElement('select');
    for (let year = startYearRange; year <= currentYear + 5; year++) {  // Allow 5 future years
        const option = document.createElement('option');
        option.value = year;
        option.textContent = year;
        endYearSelect.appendChild(option);
    }

    // Location input
    const locationLabel = document.createElement('label');
    locationLabel.textContent = 'Location:';
    const locationInput = document.createElement('input');
    locationInput.type = 'text';
    locationInput.placeholder = 'Enter location';

    // Description textarea
    const descriptionLabel = document.createElement('label');
    descriptionLabel.textContent = 'Description (max 250 characters):';
    const descriptionTextarea = document.createElement('textarea');
    descriptionTextarea.maxLength = 250;
    descriptionTextarea.placeholder = 'Enter description';
    descriptionTextarea.rows = 4;

    // Remove button
    const removeButton = document.createElement('button');
    removeButton.textContent = 'Delete';
    removeButton.addEventListener('click', function () {
        newForm.remove();
    });

    // Append elements to form
    newForm.appendChild(companyLabel);
    newForm.appendChild(companyNameInput);
    newForm.appendChild(titleLabel);
    newForm.appendChild(titleInput);
    newForm.appendChild(employmentLabel);
    newForm.appendChild(employmentSelect);
    newForm.appendChild(startLabel);
    newForm.appendChild(startMonthSelect);
    newForm.appendChild(startYearSelect);
    newForm.appendChild(endLabel);
    newForm.appendChild(endMonthSelect);
    newForm.appendChild(endYearSelect);
    newForm.appendChild(locationLabel);
    newForm.appendChild(locationInput);
    newForm.appendChild(descriptionLabel);
    newForm.appendChild(descriptionTextarea);
    newForm.appendChild(removeButton);

    // Append the new form to the container
    document.getElementById('formContainer').appendChild(newForm);
});

document.getElementById('addEducationFormButton').addEventListener('click', function () {
    const newForm = document.createElement('div');
    newForm.classList.add('form-container');

    // School Name input
    const schoolLabel = document.createElement('label');
    schoolLabel.textContent = 'School Name:';
    const schoolNameInput = document.createElement('input');
    schoolNameInput.type = 'text';
    schoolNameInput.placeholder = 'Enter school name';

    // Degree input
    const degreeLabel = document.createElement('label');
    degreeLabel.textContent = 'Degree:';
    const degreeInput = document.createElement('input');
    degreeInput.type = 'text';
    degreeInput.placeholder = 'Enter degree';

    // Start Year and End Year dropdowns
    const yearLabel = document.createElement('label');
    yearLabel.textContent = 'Years:';

    const startYearSelect = document.createElement('select');
    const startYearRange = 1990;
    const currentYear = new Date().getFullYear();
    for (let year = startYearRange; year <= currentYear; year++) {
        const option = document.createElement('option');
        option.value = year;
        option.textContent = year;
        startYearSelect.appendChild(option);
    }

    const endYearSelect = document.createElement('select');
    for (let year = startYearRange; year <= currentYear + 5; year++) {
        const option = document.createElement('option');
        option.value = year;
        option.textContent = year;
        endYearSelect.appendChild(option);
    }

    // City input
    const cityLabel = document.createElement('label');
    cityLabel.textContent = 'City:';
    const cityInput = document.createElement('input');
    cityInput.type = 'text';
    cityInput.placeholder = 'Enter city';

    // Description textarea with max 250 characters
    const descriptionLabel = document.createElement('label');
    descriptionLabel.textContent = 'Description (max 250 characters):';
    const descriptionTextarea = document.createElement('textarea');
    descriptionTextarea.maxLength = 250;
    descriptionTextarea.placeholder = 'Enter description';
    descriptionTextarea.rows = 4;

    // Remove button
    const removeButton = document.createElement('button');
    removeButton.textContent = 'Delete';
    removeButton.addEventListener('click', function () {
        newForm.remove();
    });

    // Append all elements to the form container
    newForm.appendChild(schoolLabel);
    newForm.appendChild(schoolNameInput);
    newForm.appendChild(degreeLabel);
    newForm.appendChild(degreeInput);
    newForm.appendChild(yearLabel);
    newForm.appendChild(startYearSelect);
    newForm.appendChild(endYearSelect);
    newForm.appendChild(cityLabel);
    newForm.appendChild(cityInput);
    newForm.appendChild(descriptionLabel);
    newForm.appendChild(descriptionTextarea);
    newForm.appendChild(removeButton);

    // Append the new form to the container
    document.getElementById('formContainer').appendChild(newForm);
});

// Function to add Personal Website Form
document.getElementById('addWebsiteFormButton').addEventListener('click', function () {
    const newForm = document.createElement('div');
    newForm.classList.add('form-container');

    // Label input for the website
    const labelLabel = document.createElement('label');
    labelLabel.textContent = 'Label (e.g. Portfolio, Blog):';
    const labelInput = document.createElement('input');
    labelInput.type = 'text';
    labelInput.placeholder = 'Enter label';

    // URL input for the website
    const urlLabel = document.createElement('label');
    urlLabel.textContent = 'Website URL:';
    const urlInput = document.createElement('input');
    urlInput.type = 'url';
    urlInput.placeholder = 'Enter URL';

    // Remove button
    const removeButton = document.createElement('button');
    removeButton.textContent = 'Delete';
    removeButton.addEventListener('click', function () {
        newForm.remove();
    });

    // Append all elements to the form container
    newForm.appendChild(labelLabel);
    newForm.appendChild(labelInput);
    newForm.appendChild(urlLabel);
    newForm.appendChild(urlInput);
    newForm.appendChild(removeButton);

    // Append the new form to the container
    document.getElementById('formContainer').appendChild(newForm);
});

// Function to add Skill Form
document.getElementById('addSkillFormButton').addEventListener('click', function () {
    const newForm = document.createElement('div');
    newForm.classList.add('form-container');

    // Skills input (comma-separated)
    const skillsLabel = document.createElement('label');
    skillsLabel.textContent = 'Skills (comma separated):';
    const skillsInput = document.createElement('input');
    skillsInput.type = 'text';
    skillsInput.placeholder = 'Enter skills separated by commas';

    // Remove button
    const removeButton = document.createElement('button');
    removeButton.textContent = 'Delete';
    removeButton.addEventListener('click', function () {
        newForm.remove();
    });

    // Append all elements to the form container
    newForm.appendChild(skillsLabel);
    newForm.appendChild(skillsInput);
    newForm.appendChild(removeButton);

    // Append the new form to the container
    document.getElementById('formContainer').appendChild(newForm);
});

// Function to handle form submission
//document.getElementById('submitFormButton').addEventListener('click', function () {
//    const formsData = [];

//    // Loop through all dynamically created forms and collect data
//    const formContainers = document.querySelectorAll('.form-container');

//    formContainers.forEach(form => {
//        const formData = {};

//        // Employment forms
//        const companyNameInput = form.querySelector('input[placeholder="Enter company name"]');
//        if (companyNameInput) formData.companyName = companyNameInput.value;

//        const titleInput = form.querySelector('input[placeholder="Enter job title"]');
//        if (titleInput) formData.jobTitle = titleInput.value;

//        const employmentSelect = form.querySelector('select');
//        if (employmentSelect) formData.employmentType = employmentSelect.value;

//        const startMonthSelect = form.querySelector('select');
//        if (startMonthSelect) formData.startMonth = startMonthSelect.value;

//        const startYearSelect = form.querySelector('select');
//        if (startYearSelect) formData.startYear = startYearSelect.value;

//        const locationInput = form.querySelector('input[placeholder="Enter location"]');
//        if (locationInput) formData.location = locationInput.value;

//        const descriptionTextarea = form.querySelector('textarea');
//        if (descriptionTextarea) formData.description = descriptionTextarea.value;

//        formsData.push(formData);
//    });

//    // Here, you can log the formsData or send it to the server
//    console.log(formsData);
//});

// Function to handle form submission
document.getElementById('submitFormButton').addEventListener('click', function () {
    const formsData = [];

    // Loop through all dynamically created forms and collect data
    const formContainers = document.querySelectorAll('.form-container');

    formContainers.forEach(form => {
        const formData = {};

        // Employment Form - Collecting data specifically from Employment form fields
        if (form.querySelector('input[placeholder="Enter company name"]')) {
            formData.formType = 'Employment';

            const companyNameInput = form.querySelector('input[placeholder="Enter company name"]');
            formData.companyName = companyNameInput ? companyNameInput.value : '';

            const titleInput = form.querySelector('input[placeholder="Enter job title"]');
            formData.jobTitle = titleInput ? titleInput.value : '';

            const employmentSelect = form.querySelector('select');
            formData.employmentType = employmentSelect ? employmentSelect.value : '';

            const startMonthSelect = form.querySelector('select');
            formData.startMonth = startMonthSelect ? startMonthSelect.value : '';

            const startYearSelect = form.querySelector('select');
            formData.startYear = startYearSelect ? startYearSelect.value : '';

            const locationInput = form.querySelector('input[placeholder="Enter location"]');
            formData.location = locationInput ? locationInput.value : '';

            const descriptionTextarea = form.querySelector('textarea');
            formData.description = descriptionTextarea ? descriptionTextarea.value : '';
        }

        // Education Form - Collecting data specifically from Education form fields
        else if (form.querySelector('input[placeholder="Enter school name"]')) {
            formData.formType = 'Education';

            const schoolNameInput = form.querySelector('input[placeholder="Enter school name"]');
            formData.schoolName = schoolNameInput ? schoolNameInput.value : '';

            const degreeInput = form.querySelector('input[placeholder="Enter degree"]');
            formData.degree = degreeInput ? degreeInput.value : '';

            const startYearSelect = form.querySelector('select');
            formData.startYear = startYearSelect ? startYearSelect.value : '';

            const endYearSelect = form.querySelector('select');
            formData.endYear = endYearSelect ? endYearSelect.value : '';

            const cityInput = form.querySelector('input[placeholder="Enter city"]');
            formData.city = cityInput ? cityInput.value : '';

            const eduDescriptionTextarea = form.querySelector('textarea');
            formData.eduDescription = eduDescriptionTextarea ? eduDescriptionTextarea.value : '';
        }

        // Website Form - Collecting data specifically from Website form fields
        else if (form.querySelector('input[placeholder="Enter label"]')) {
            formData.formType = 'Website';

            const labelInput = form.querySelector('input[placeholder="Enter label"]');
            formData.label = labelInput ? labelInput.value : '';

            const urlInput = form.querySelector('input[placeholder="Enter URL"]');
            formData.url = urlInput ? urlInput.value : '';
        }

        // Skill Form - Collecting data specifically from Skill form fields
        else if (form.querySelector('input[placeholder="Enter skills separated by commas"]')) {
            formData.formType = 'Skills';

            const skillsInput = form.querySelector('input[placeholder="Enter skills separated by commas"]');
            formData.skills = skillsInput ? skillsInput.value.split(',').map(skill => skill.trim()) : [];
        }

        // Push the collected data into the formsData array
        formsData.push(formData);
    });

    // Here, you can log the formsData or send it to the server
    console.log(formsData);
});

