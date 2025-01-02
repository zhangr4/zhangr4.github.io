import requests


def get_github_stars(repo_owner, repo_name, token=None):
    """
    Fetch the number of stars for a given GitHub repository.

    Args:
        repo_owner (str): The owner of the repository (e.g., 'torvalds').
        repo_name (str): The name of the repository (e.g., 'linux').
        token (str, optional): GitHub personal access token for authentication (if needed).

    Returns:
        int: The number of stars for the repository.
    """
    url = f"https://api.github.com/repos/{repo_owner}/{repo_name}"
    headers = {}

    if token:
        headers['Authorization'] = f"token {token}"

    response = requests.get(url, headers=headers)

    if response.status_code == 200:
        data = response.json()
        return data.get('stargazers_count', 0)
    else:
        print(f"Error: Unable to fetch details (HTTP {response.status_code})")
        return None


if __name__ == "__main__":
    # Example: Fetching stars for the 'linux' repository by 'torvalds'

    repositories = {
        "kiota": "Microsoft",
        "refit": "reactiveui",
        "Flurl": "tmenier",
        "RestSharp": "restsharp",
    }

    for repo_name, repo_owner in repositories.items():
        stars = get_github_stars(repo_owner, repo_name)
        if stars is not None:
            print(f"The repository '{repo_owner}/{repo_name}' "
                  f"has {stars} stars.")
