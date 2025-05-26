package com.filmmodu

import com.lagradost.cloudstream3.*
import com.lagradost.cloudstream3.utils.*

class FilmModu : MainAPI() {
    override var name = "FilmModu"
    override var mainUrl = "https://www.filmmodu.nl"
    override val hasMainPage = true
    override val supportedTypes = setOf(TvType.Movie)

    override suspend fun getMainPage(page: Int, request: MainPageRequest): HomePageResponse {
        val movies = listOf(
            newMovieSearchResponse("Test Filmi 1", "$mainUrl/test1", TvType.Movie) {
                this.posterUrl = "https://via.placeholder.com/300x450?text=Test+1"
            },
            newMovieSearchResponse("Test Filmi 2", "$mainUrl/test2", TvType.Movie) {
                this.posterUrl = "https://via.placeholder.com/300x450?text=Test+2"
            }
        )
        return HomePageResponse(listOf(HomePageList("Test Filmleri", movies)))
    }

    override suspend fun load(url: String): LoadResponse {
        return newMovieLoadResponse("Test Filmi 1", url, TvType.Movie, url) {
            this.posterUrl = "https://via.placeholder.com/300x450?text=Test+1"
            this.plot = "Bu sadece test amaçlı sahte bir film açıklamasıdır."
            this.year = 2025
        }
    }

    override suspend fun search(query: String): List<SearchResponse> {
        return listOf(
            newMovieSearchResponse("Arama Sonucu: $query", "$mainUrl/search?q=$query", TvType.Movie) {
                this.posterUrl = "https://via.placeholder.com/300x450?text=Search"
            }
        )
    }
}
