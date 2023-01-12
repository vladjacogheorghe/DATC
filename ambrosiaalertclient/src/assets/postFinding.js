export async function postFinding(findingToPost) {
    let finding;
    try {
        const response = await fetch('https://localhost:7087/findings', {
            method: 'POST',
            headers: {
                'Content-Type': "application/json; charset=utf-8",
            },
            body: {
                inputCreateFinding: findingToPost
            }
        })
        finding = response.json();
    } catch (err) {
        console.log("Error: could not fetch Findings!");
    }

    return finding;
}

