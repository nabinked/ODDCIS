export interface SearchResultItemModel {
    title: string,
    url: string,
    excerpt: string
}

export interface SearchResultItemListModel {
    results: SearchResultItemModel[];
    executedSparqlQuery: string;
    requestedSemanticQuery: string;
}
