---
author: Zhang Ran
date: 25-Dec-2023
taxonomies:
  - tags: ["Visual Studio", "Git", "Github", "GPG"]
---

# Verify Git Commit

- Environment

  - Currently using Windows 11.
  - Visual Studio 2022 Community is installed.
  - Git is also installed.

While following the steps from [Microsoft](https://learn.microsoft.com/en-us/visualstudio/version-control/git-create-repository?view=vs-2022#create-a-github-repo) to initialize a local git repository and push to a newly created git repository on GitHub using Visual Studio, some issues were encountered:

### Issue: Visual Studio Repeatedly Requests Credentials ⚠️

Refer to this [article](https://blog.jongallant.com/2021/08/visual-studio-re-enter-credentials/). The sign-in options should use "System web browser" instead of the default "embedded browser auth" for "Add and reauthenticate accounts using."

### Issue: Git Commit Failed with Git-Hook Error

Error message: "Your git-hook, 'gpg,' is not supported, likely because the first line is not '#!/bin/sh'.\r\nSee your administrator for additional assistance."

When initializing the git repository, a hook for GPG is added. GPG stands for [The GNU Privacy Guard](https://www.gnupg.org/). When used on GitHub, it helps ["to sign commits associated with your account on GitHub, you can add a public GPG key to your personal account"](https://docs.github.com/en/authentication/managing-commit-signature-verification/adding-a-gpg-key-to-your-github-account#about-addition-of-gpg-keys-to-your-account)

Solution:

Refer to this [link](https://developercommunity.visualstudio.com/t/git-commit-failed-with-git-hook-error/139363). Check if the file `C:\Program Files\Git\usr\bin\gpg.exe` exists. By default, Visual Studio should install it. If not, install gpg.exe first.

After installation, add the GPG bin folder (by default `C:\Program Files\Git\usr\bin`) to your `%PATH%`.

### Issue: "Error: cannot spawn C:\Program Files (x86)\GnuPG\bin\gpg.exe: No such file or directory"

Once gpg.exe is installed, set the path of gpg.exe in git config using `git config --global gpg.program "C:\Program Files\Git\usr\bin\gpg.exe"` to ensure that git can find gpg.

### Issue: "gpg: skipped: No secret key"

Error message: "gpg: signing failed: No secret key." This means there is no GPG secret key. [Generating a new GPG key](https://docs.github.com/en/authentication/managing-commit-signature-verification/generating-a-new-gpg-key) and [inform Git about your GPG key](https://docs.github.com/en/authentication/managing-commit-signature-verification/telling-git-about-your-signing-key#telling-git-about-your-gpg-key).

(Optional) For GitHub Verification, ensure you have:

1. [Verified you email address](https://docs.github.com/en/account-and-profile/setting-up-and-managing-your-personal-account-on-github/managing-email-preferences/verifying-your-email-address).

2. [Set your commit email address](https://docs.github.com/en/account-and-profile/setting-up-and-managing-your-personal-account-on-github/managing-email-preferences/setting-your-commit-email-address).

3. [Associated your verified email with your GPG key](https://docs.github.com/en/authentication/managing-commit-signature-verification/associating-an-email-with-your-gpg-key).

4. [Added GPG key to github](https://docs.github.com/en/authentication/managing-commit-signature-verification/adding-a-gpg-key-to-your-github-account).

Then finally, you would got your commit verified.![commit verified](https://docs.github.com/assets/cb-97945/mw-1440/images/help/settings/gpg-verified-with-expired-key.webp).
