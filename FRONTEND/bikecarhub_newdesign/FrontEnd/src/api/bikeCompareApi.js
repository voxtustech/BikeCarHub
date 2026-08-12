import { API_BASE } from "../config";

/*
export async function getBikeComparison(bike1Id, bike2Id) {

    if (!bike1Id || !bike2Id)
        return null;

    const response = await fetch(
        `${API_BASE}/bikecompare/${bike1Id}/${bike2Id}`
    );

    if (!response.ok)
        throw new Error("Unable to load comparison.");

    return await response.json();
}
*/

//date:11/08/26
/*
export async function getBikeComparison(
    bike1Id,
    variant1Id,
    bike2Id,
    variant2Id
) {

    if (
        !bike1Id ||
        !variant1Id ||
        !bike2Id ||
        !variant2Id
    ) {
        return null;
    }

    const response = await fetch(
        `${API_BASE}/BikeCompareApi/${bike1Id}/${variant1Id}/${bike2Id}/${variant2Id}`
    );

    if (!response.ok)
        throw new Error("Unable to load comparison.");

    return await response.json();
}
*/

/*
export async function getBikeComparison(variant1, variant2) {

    console.log(
        "Comparing variants:",
        variant1,
        variant2
    );

    const response = await fetch(
        `${API_BASE}/api/compare?variant1=${variant1}&variant2=${variant2}`,
        {
            credentials: "include"
        }
    );

    if (!response.ok) {

        const errorText = await response.text();

        console.error(
            "Comparison API error:",
            response.status,
            errorText
        );

        throw new Error(
            "Unable to load comparison."
        );
    }

    return await response.json();
}

*/

export async function getBikeComparison(
    bike1Id,
    variant1Id,
    bike2Id,
    variant2Id
) {

    console.log("Comparison IDs:", {
        bike1Id,
        variant1Id,
        bike2Id,
        variant2Id
    });

    const response = await fetch(
        `${API_BASE}/BikeCompareApi/${bike1Id}/${variant1Id}/${bike2Id}/${variant2Id}`,
        {
            credentials: "include"
        }
    );

    if (!response.ok) {

        const errorText = await response.text();

        console.error(
            "Comparison API error:",
            response.status,
            errorText
        );

        throw new Error(
            `Unable to load comparison. Status: ${response.status}`
        );
    }

    return await response.json();
}

export async function getBikeList() {

    const response = await fetch(
        `${API_BASE}/bikes`
    );

    if (!response.ok)
        throw new Error("Unable to load bikes.");

    return await response.json();
}