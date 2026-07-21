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

export async function getBikeList() {

    const response = await fetch(
        `${API_BASE}/bikes`
    );

    if (!response.ok)
        throw new Error("Unable to load bikes.");

    return await response.json();
}