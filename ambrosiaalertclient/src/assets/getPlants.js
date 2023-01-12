export async function getPlants() {
    let plants;
    try {
        const response = await fetch('https://localhost:7087/plants',
            {
                method: 'get',
                headers: {
                    'content-type': "application/json; charset=utf-8",
                }
            })
            findings = response.json();
            // console.log("get findings:", findings);
    } catch (err) {
        console.log("Error: could not fetch Findings!");
    }

    return plants;
}