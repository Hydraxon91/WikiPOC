# WikiPOC

Welcome to WikiPOC, short for Wiki Proof Of Concept! 

WikiPOC is a free and open-source proof of concept framework inspired by Wikipedia. 

It was created to explore the feasibility of building a Wikipedia-like platform with modern web technologies.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

WikiPOC is a free and open-source proof of concept framework inspired by Wikipedia. It aims to provide a customizable, extensible, and accessible platform for collaborative content creation and dissemination.

## Why WikiPOC

WikiPOC was created to address the need for a flexible and scalable platform for collaborative content creation. Traditional content management systems often lack the features required for community-driven projects, such as Wikipedia. By providing a framework tailored to the needs of collaborative projects, WikiPOC empowers users to create and share knowledge in a structured and organized manner.

## Features

- User-friendly interface for content creation and editing
- Customizable styling and theming options
- Support for multimedia content including images and videos (**W.I.P**)
- Community-driven moderation and quality control (**W.I.P**)
- Integration with popular authentication systems for user management (**W.I.P**)

## Installation

To install WikiPOC, follow these steps:

1. Clone the repository: `git clone https://github.com/Hydraxon91/WikiPOC.git`
2. Navigate to the Main directory: `cd WikiPOC/`
3. Create a `.env` file with the following environment variables:
   - `ASPNETCORE_CONNECTIONSTRING`: Connection string for the database
   - `ADMINUSER_EMAIL`: Email address for the admin user (Will add the ability to create new administrators)
   - `ADMINUSER_PASSWORD`: Password for the admin user
   - `ADMINUSER_USERNAME`: Username for the admin user
   - `TESTUSER_EMAIL`: Email address for the test user
   - `TESTUSER_PASSWORD`: Password for the test user
   - `TESTUSER_USERNAME`: Username for the test user
   - `JWT_ISSUER_SIGNING_KEY`: Secret key for JWT token signing
   - `JWT_VALID_AUDIENCE`: Valid audience for JWT tokens
   - `JWT_VALID_ISSUER`: Valid issuer for JWT tokens
   - `JWT_TOKEN_TIME`: Expiry time for JWT tokens
   - `PICTURES_PATH`: Path for pictures
   - `PICTURES_PATH_CONTAINER`: Container path for pictures
   - `DB_PASSWORD`: Password for the database
   - `REACT_APP_API_URL`: URL for the API endpoint
4. Start the services using Docker Compose: `docker-compose up`


## Usage

To use WikiPOC, follow these guidelines:

- Navigate to the deployed application in your web browser.
- Create an account or log in if you already have one.
- Explore existing articles or create new ones by clicking on the "Create" button.
- Customize the theme, name, and logo of the wiki according to your preferences.
- Submit new pages by filling out the required information and submitting them for approval. Admins can submit pages freely.
- Admins will review and approve new pages before they are published.
- Edit existing pages by clicking on the "Edit" button and making changes. Admins can edit pages freely.
- Customize your user profile by updating your personal information and preferences.
- Leave comments on pages to engage in discussions and provide feedback.

Note: As this project is still a work in progress and I'm a beginner, I haven't tried deploying it yet to any services.



## Contributing

We welcome contributions from the community! If you'd like to contribute to WikiPOC, please follow these guidelines:

- Report bugs and suggest features by opening an issue.
- Submit pull requests with your contributions, following the project's coding conventions and guidelines.
- Join the discussion on our community forums and help improve WikiPOC together.

## License 
WikiPOC is open-source software licensed under the [MIT License](https://opensource.org/licenses/MIT).
