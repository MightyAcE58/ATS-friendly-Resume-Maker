<%@ Page Language="C#" MasterPageFile="~/Header.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ATS_friendly_Resume_Maker.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Page-specific head content -->
    <meta name="description" content="">
    <meta name="keywords" content="">

    <!-- Favicons -->
    <link href="assets/img/favicon.png" rel="icon">
    <link href="assets/img/apple-touch-icon.png" rel="apple-touch-icon">

    <!-- Fonts -->
    <link href="https://fonts.googleapis.com" rel="preconnect">
    <link href="https://fonts.gstatic.com" rel="preconnect" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;..." rel="stylesheet">

    <!-- Vendor CSS Files -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <link href="assets/vendor/aos/aos.css" rel="stylesheet">

    <!-- Main CSS File -->
    <link href="main.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <main class="main">
        <!-- Hero Section -->
        <section id="hero" class="hero section dark-background">
            <img src="assets/img/hero-bg-2.jpg" alt="" class="hero-bg">

            <div class="container">
                <div class="row gy-4 justify-content-between">
                    <div class="col-lg-4 order-lg-last hero-img" data-aos="zoom-out" data-aos-delay="100">
                        <img src="assets/img/hero-img.png" class="img-fluid animated" alt="">
                    </div>

                    <div class="col-lg-6  d-flex flex-column justify-content-center" data-aos="fade-in">
                        <h1>Build Your Outstanding Resume With <span>Resume<b style="color: rgb(199, 56, 255);">Pro</b></span></h1>
                        <p>We make Resume that make you stand out  </p>
                        <div class="d-flex">
                            <a href="form.aspx" class="btn-get-started">Get Started</a>
                            <!--important-->
                            <div class="glightbox btn-watch-video d-flex align-items-center"></div>
                        </div>
                    </div>

                </div>
            </div>

            <svg class="hero-waves" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 24 150 28 " preserveAspectRatio="none">
                <defs>
                    <path id="wave-path" d="M-160 44c30 0 58-18 88-18s 58 18 88 18 58-18 88-18 58 18 88 18 v44h-352z"></path>
                </defs>
                <g class="wave1">
                    <use xlink:href="#wave-path" x="50" y="3"></use>
                </g>
                <g class="wave2">
                    <use xlink:href="#wave-path" x="50" y="0"></use>
                </g>
                <g class="wave3">
                    <use xlink:href="#wave-path" x="50" y="9"></use>
                </g>
            </svg>

        </section>

        <!-- About Section -->
        <section id="about" class="about section">

            <div class="container" data-aos="fade-up" data-aos-delay="100">
                <div class="row align-items-xl-center gy-5">

                    <div class="col-xl-6 content">
                        <h3>About Us</h3>
                        <h2>Resume<b style="color: rgb(199, 56, 255);">Pro</b> – Build. Optimize. Get Hired.</h2>
                        <p>
                            At ResumePro, we believe that a well-crafted resume is the key to unlocking career opportunities. Our platform helps job seekers create professional, ATS-friendly resumes tailored to their desired roles. Whether you're a recent graduate, a seasoned professional, or making a career switch, we simplify the resume-building process with customizable templates, job-specific suggestions, and an intuitive interface.

      Our mission is to empower users with the tools they need to stand out in the competitive job market. With ResumePro, you can build a resume that not only looks great but also gets noticed by recruiters. Let’s take your career to the next level—one tailored resume at a time!.
                        </p>

                    </div>

                    <div class="col-xl-6 ">
                        <div class="row gy-4 icon-boxes">

                            <div class="col-md-6" data-aos="fade-up" data-aos-delay="100">
                                <div class="icon-box">
                                    <i class="bi bi-buildings"></i>
                                    <h3>Professional Resume Templates</h3>
                                    <p>MChoose from a variety of modern, industry-specific resume templates designed to stand out.</p>
                                </div>
                            </div>
                            <!-- End Icon Box -->

                            <div class="col-md-6" data-aos="fade-up" data-aos-delay="300">
                                <div class="icon-box">
                                    <i class="bi bi-clipboard-pulse"></i>
                                    <h3>Easy Customization/h3>
                                    <p>Edit and personalize your resume with a user-friendly interface, allowing quick updates and adjustments.</p>
                                </div>
                            </div>
                            <!-- End Icon Box -->

                            <div class="col-md-6" data-aos="fade-up" data-aos-delay="400">
                                <div class="icon-box">
                                    <i class="bi bi-command"></i>
                                    <h3>One-Click Export & Sharing</h3>
                                    <p>Download your resume in PDF share it directly with recruiters via email or LinkedIn.</p>
                                </div>
                            </div>
                            <!-- End Icon Box -->

                            <div class="col-md-6" data-aos="fade-up" data-aos-delay="500">
                                <div class="icon-box">
                                    <i class="bi bi-graph-up-arrow"></i>
                                    <h3>Job-Specific Resume Suggestions
</h3>
                                    <p>Get tailored resume recommendations based on your target job role and industry trends.</p>
                                </div>
                            </div>
                            <!-- End Icon Box -->

                        </div>
                    </div>

                </div>
            </div>

        </section>

        <!-- Features Section -->
        <section id="features" class="features section">

            <div class="container">
                <div class="container section-title" data-aos="fade-up">
                    <h2>Features</h2>
                    <div><span>Check Our</span> <span class="description-title">Features</span></div>
                </div>
                <!-- End Section Title -->

                <div class="row gy-4">

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="100">
                        <div class="features-item">
                            <i class="bi bi-eye" style="color: #ffbb2c;"></i>
                            <h3><a href="" class="stretched-link">Resume Preview
</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="200">
                        <div class="features-item">
                            <i class="bi bi-infinity" style="color: #5578ff;"></i>
                            <h3><a href="" class="stretched-link">Unlimited Edits</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="300">
                        <div class="features-item">
                            <i class="bi bi-mortarboard" style="color: #e80368;"></i>
                            <h3><a href="" class="stretched-link">Smart Formatting</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="400">
                        <div class="features-item">
                            <i class="bi bi-nut" style="color: #e361ff;"></i>
                            <h3><a href="" class="stretched-link"> Customizable Sections</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="500">
                        <div class="features-item">
                            <i class="bi bi-shuffle" style="color: #47aeff;"></i>
                            <h3><a href="" class="stretched-link"> ATS-Friendly Resumes</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="600">
                        <div class="features-item">
                            <i class="bi bi-star" style="color: #ffa76e;"></i>
                            <h3><a href="" class="stretched-link">One-Click Cover Letter</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="700">
                        <div class="features-item">
                            <i class="bi bi-x-diamond" style="color: #11dbcf;"></i>
                            <h3><a href="" class="stretched-link">Secure Cloud Storage</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->

                    <div class="col-lg-3 col-md-4" data-aos="fade-up" data-aos-delay="800">
                        <div class="features-item">
                            <i class="bi bi-camera-video" style="color: #4233ff;"></i>
                            <h3><a href="" class="stretched-link">Resume Templates for Every Industry</a></h3>
                        </div>
                    </div>
                    <!-- End Feature Item -->
                </div>

            </div>

        </section>

        <!-- Details Section -->
        <section id="details" class="details section">

            <!-- Section Title -->
            <div class="container section-title" data-aos="fade-up">
                <h2>Details</h2>
                <div><span>Check Our</span> <span class="description-title">Details</span></div>
            </div>
            <!-- End Section Title -->

            <div class="container">

                <div class="row gy-4 align-items-center features-item">
                    <div class="col-md-5 d-flex align-items-center" data-aos="zoom-out" data-aos-delay="100">
                        <img src="assets/img/details-1.png" class="img-fluid" alt="">
                    </div>
                    <div class="col-md-7" data-aos="fade-up" data-aos-delay="100">
                        <h3>Smart Resume Builder.</h3>
                        <p class="fst-italic">
                            Our resume builder helps you create professional resumes effortlessly. Choose from various templates and customize them to fit your style.



                        </p>
                        <ul>
                            <li><i class="bi bi-check"></i><span>Tailored industry-specific templates</span></li>
                            <li><i class="bi bi-check"></i><span>Easy-to-use</span></li>
                         
                        </ul>
                    </div>
                </div>
                <!-- Features Item -->

                <div class="row gy-4 align-items-center features-item">
                    <div class="col-md-5 order-1 order-md-2 d-flex align-items-center" data-aos="zoom-out" data-aos-delay="200">
                        <img src="assets/img/details-2.png" class="img-fluid" alt="">
                    </div>
                    <div class="col-md-7 order-2 order-md-1" data-aos="fade-up" data-aos-delay="200">
                        <h3> ATS-Friendly Resumes</h3>
                        <p class="fst-italic">
                           ATS-approved templates
                        </p>
                        <p>
                          
 Ensure your resume passes through Applicant Tracking Systems (ATS) with optimized formatting and keyword integration.
✅ Keyword optimization
✅ Increased job application success
                        </p>
                    </div>
                </div>
                <!-- Features Item -->
        </section>

        <!-- Team Section -->
        <section id="team" class="team section">

            <!-- Section Title -->
            <div class="container section-title" data-aos="fade-up">
                <h2>Team</h2>
                <div><span>Check Our</span> <span class="description-title">Team</span></div>
            </div>
            <!-- End Section Title -->

            <div class="container">

                <div class="row gy-5" style="justify-content: center;">

                    <div class="col-lg-4 col-md-6" data-aos="fade-up" data-aos-delay="100">
                        <div class="member">
                            <div class="pic">
                                <img src="assets/img/team/vinay.jpeg" class="img-fluid" alt="">
                            </div>
                            <div class="member-info" style="background-color: rgba(128, 128, 128, 0.329);">
                                <h4>Vinay Tilada</h4>
                                <span style="font-size: 1rem;">Backend & Delpoyment</span>
                                <div class="social">
                                  
                                   
                                    <a href="https://www.linkedin.com/in/vinaytilada/"><i class="bi bi-linkedin"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 " data-aos="fade-up" data-aos-delay="200">
                        <div class="member">
                            <div class="pic">
                                <img src="assets/img/team/vansh.jpg" class="img-fluid" alt="">
                            </div>
                            <div class="member-info" style="background-color: rgba(128, 128, 128, 0.329);">
                                <h4>Vansh Jain</h4>
                                <span style="font-size: 1rem;">Full Stack Developer</span>
                                <div class="social">
                               
                                    <a href="https://www.linkedin.com/in/codewithvansh-jain/"><i class="bi bi-linkedin"></i></a>
                                </div>
                            </div>
                        </div>
                    </div>



                </div>

            </div>

        </section>

        <!-- Footer -->
        <footer style="background-color: #f8f9fa; padding: 20px; text-align: center; margin-top: auto; height: 10rem;">
            <div style="padding-top: 2rem; padding-bottom: 10px; border-top: 0px solid #ddd;">
                <div style="max-width: 1200px; margin: 0 auto;">
                    <div style="display: flex; justify-content: space-between; align-items: center; flex-wrap: wrap;">
                        <div style="text-align: center; flex: 1;">
                            <div style="font-size: 14px; color: #6c757d;">
                                &copy; 2025. All Rights Reserved.
                            </div>
                            <div style="margin-top: 10px; font-size: 1rem; color: #6c757d;">
                                <a href="/Home/Index" style="text-decoration: none; color: #6c757d;">Built by </a>
                                <a href="https://www.linkedin.com/in/vinaytilada/" style="color: rgba(36, 85, 189, 0.747); text-decoration: none;">Vinay Tilada</a> <span style="color: #e40f2b;">🫂</span>
                                <a href="https://www.linkedin.com/in/codewithvansh-jain/" style="color: rgba(36, 85, 189, 0.747); text-decoration: none;">Vansh Jain</a>
                                with <span style="color: #ff6f61;">❤️</span>
                            </div>

                        </div>
                        <div style="flex: 1; text-align: center;">
                            <ul style="list-style-type: none; margin: 0; padding: 0; display: flex; justify-content: center;">
                                <li style="margin-right: 2rem;">
                                    <a href="https://github.com/MightyAcE58/ATS-friendly-Resume-Maker" style="color: #9f15c9; text-decoration: none;">
                                        <!-- GitHub Icon -->
                                        <svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" fill="currentColor" class="bi bi-github" viewBox="0 0 24 24">
                                            <path d="M12 0c-6.626 0-12 5.373-12 12 0 5.302 3.438 9.8 8.207 11.387.599.111.793-.261.793-.577v-2.234c-3.338.726-4.033-1.416-4.033-1.416-.546-1.387-1.333-1.756-1.333-1.756-1.089-.745.083-.729.083-.729 1.205.084 1.839 1.237 1.839 1.237 1.07 1.834 2.807 1.304 3.492.997.107-.775.418-1.305.762-1.604-2.665-.305-5.467-1.334-5.467-5.931 0-1.311.469-2.381 1.236-3.221-.124-.303-.535-1.524.117-3.176 0 0 1.008-.322 3.301 1.23.957-.266 1.983-.399 3.003-.404 1.02.005 2.047.138 3.006.404 2.291-1.552 3.297-1.23 3.297-1.23.653 1.653.242 2.874.118 3.176.77.84 1.235 1.911 1.235 3.221 0 4.609-2.807 5.624-5.479 5.921.43.372.823 1.102.823 2.222v3.293c0 .319.192.694.801.576 4.765-1.589 8.199-6.086 8.199-11.386 0-6.627-5.373-12-12-12z" />
                                        </svg>
                                    </a>
                                </li>
                                <li style="margin-right: 2rem;">
                                    <a href="#!" style="color: #da0a0a; text-decoration: none;">
                                        <!-- YouTube Icon -->
                                        <svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" fill="currentColor" class="bi bi-youtube" viewBox="0 0 16 16">
                                            <path d="M8.051 1.999h.089c.822.003 4.987.033 6.11.335a2.01 2.01 0 0 1 1.415 1.42c.101.38.172.883.22 1.402l.01.104.022.26.008.104c.065.914.073 1.77.074 1.957v.075c-.001.194-.01 1.108-.082 2.06l-.008.105-.009.104c-.05.572-.124 1.14-.235 1.558a2.007 2.007 0 0 1-1.415 1.42c-1.16.312-5.569.334-6.18.335h-.142c-.309 0-1.587-.006-2.927-.052l-.17-.006-.087-.004-.171-.007-.171-.007c-1.11-.049-2.167-.128-2.654-.26a2.007 2.007 0 0 1-1.415-1.419c-.111-.417-.185-.986-.235-1.558L.09 9.82l-.008-.104A31.4 31.4 0 0 1 0 7.68v-.123c.002-.215.01-.958.064-1.778l.007-.103.003-.052.008-.104.022-.26.01-.104c.048-.519.119-1.023.22-1.402a2.007 2.007 0 0 1 1.415-1.42c.487-.13 1.544-.21 2.654-.26l.17-.007.172-.006.086-.003.171-.007A99.788 99.788 0 0 1 7.858 2h.193zM6.4 5.209v4.818l4.157-2.408L6.4 5.209z" />
                                        </svg>
                                    </a>
                                </li>
                                <li style="margin-right: 2rem;">
                                    <a href="#!" style="color: #076adb; text-decoration: none;">
                                        <!-- LinkedIn Icon -->
                                        <svg xmlns="http://www.w3.org/2000/svg" width="36" height="36" fill="currentColor" class="bi bi-linkedin" viewBox="0 0 24 24">
                                            <path d="M19 0h-14c-2.761 0-5 2.239-5 5v14c0 2.761 2.239 5 5 5h14c2.762 0 5-2.239 5-5v-14c0-2.761-2.238-5-5-5zm-11 19h-3v-11h3v11zm-1.5-12.268c-.966 0-1.75-.79-1.75-1.764s.784-1.764 1.75-1.764 1.75.79 1.75 1.764-.783 1.764-1.75 1.764zm13.5 12.268h-3v-5.604c0-3.368-4-3.113-4 0v5.604h-3v-11h3v1.765c1.396-2.586 7-2.777 7 2.476v6.759z" />
                                        </svg>
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    </main>

    <!-- Scroll Top -->
    <a href="#" id="scroll-top" class="scroll-top d-flex align-items-center justify-content-center">
        <i class="bi bi-arrow-up-short"></i>
    </a>

    <!-- Preloader -->
    <div id="preloader"></div>

    <!-- Scripts -->
    <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="assets/vendor/aos/aos.js"></script>
    <script src="assets/js/main.js"></script>

    /*<script>
        document.addEventListener("DOMContentLoaded", function () {
            const faqItems = document.querySelectorAll(".faq-item");

            faqItems.forEach(item => {
                let content = item.querySelector(".faq-content");

                // Ensure only the active FAQ is open on load
                if (!item.classList.contains("faq-active")) {
                    content.style.display = "none";
                }

                item.addEventListener("click", function () {
                    // Toggle active class for the clicked item
                    this.classList.toggle("faq-active");

                    // Toggle the FAQ content visibility
                    if (content.style.display === "block") {
                        content.style.display = "none";
                    } else {
                        content.style.display = "block";
                    }
                });
            });
        });
    </script>*/
</asp:Content>
