export async function getFindings() {
    let findings;
    try {
        const response = await fetch('https://localhost:7087/findings',//'https://ambrosiaalert.azurewebsites.net/findings', //
            {
                method: 'get',
                headers: {
                    'content-type': "application/json; charset=utf-8",
                }
            })
            findings = response.json();
    } catch (err) {
        console.log("Error: could not fetch Findings!");
    }

    return findings;
}