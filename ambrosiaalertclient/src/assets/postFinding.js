export async function postFinding(findingToPost) {
    let finding;
    try {
        const response = await fetch('https://localhost:7087/findings', {//'https://ambrosiaalert.azurewebsites.net/findings',{ 
            method: 'POST',
            headers: {
                'Content-Type': "application/json; charset=utf-8",
            },
            body: JSON.stringify(
                findingToPost
            )
        })
        finding = response.json();
    } catch (err) {
        console.log("Error: could not fetch Findings!");
    }

    return finding;
}

