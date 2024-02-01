# Ceros Experience Addon for Optimizely CMS 12

The Ceros Experience Addon provides seamless integration between your Optimizely CMS 12 project and Ceros, allowing you to embed interactive Ceros experiences in your CMS without the need to manually copy and paste iframe code from the Ceros Studio. This plugin simplifies the process of integrating Ceros experiences, saving you valuable time and effort.

## Features

- Embed interactive Ceros experiences in your Optimizely CMS 12 project.
- Eliminate the need for manual copying and pasting of iframe code from Ceros Studio.
- Maintain full control over your Ceros experiences within your CMS.

## Installation

1. Install the CerosExperienceAddon package through NuGet Package Manager.
    - For this, you can use the NuGet Package Manager Console with the command: `Install-Package Ceros.Experience.Addon`.
2. Ensure that the plugin code is properly integrated into your Optimizely CMS 12 project.
3. Restart Optimizely CMS for the changes to take effect.

## Usage

### Embedding a Ceros Experience

1. In Optimizely CMS, navigate to the page where you want to add the Ceros experience.
2. Add a new block of the type 'Ceros Experience'.
3. In the new Ceros Experience block, paste the published link to your Ceros experience. This link is obtained from the Ceros Studio after you publish an experience.
4. Click "Create" or "Update" to save the changes to the block.
5. Publish the page within Optimizely CMS. The Ceros experience will be automatically embedded based on the provided link.

### Updating an Existing Ceros Experience

- To update an existing Ceros experience, simply navigate to the Ceros Experience block on your page and update the link with a new published Ceros experience link.
- Save and publish the page to reflect the changes.

## Additional Information

- This plugin was tested using the Optimizely example project 'Alloy' to ensure compatibility and proper functionality.
- The primary user flow involves creating a new custom block of the type 'Ceros Experience', inserting the published link from Ceros Studio, and embedding it directly into an Optimizely CMS page without any additional steps for embed code retrieval.

## Support

- For support or any queries related to the Ceros Experience Addon, please refer to the [GitHub repository](https://github.com/ceros/ceros-optimizely-cms-plugin).

This user guide is intended for use by users who want to understand the primary user flows and functionalities of the Ceros Experience Addon for Optimizely CMS 12.
