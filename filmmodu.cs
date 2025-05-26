package com.lagradost.cloudstream3.providers

import com.lagradost.cloudstream3.*
import com.lagradost.cloudstream3.utils.*

@ApiPlugin
class FilmModu : MainAPI() {
    override var name = "FilmModu"
    override var mainUrl = "https://www.filmmodu.nl"
    override val hasMainPage = true
    override val supportedTypes = setOf(TvType.Movie)

    override suspend fun getMainPage(page: Int, request: MainPageRequest): HomePageResponse {
        val document = app.get(mainUrl).document
        val films = document.select(".film-listesi .film").map { film ->
            val title = film.select("h2").text()
            val href = film.select("a").attr("href")
            newMovieSearchResponse(title, href, TvType.Movie) {
                posterUrl = film.select("img").attr("src")
            }
        }
        return HomePageResponse(listOf(HomePageList("FilmModu Güncel Filmler", films)))
    }

    override suspend fun load(url: String): LoadResponse {
        val document = app.get(url).document
        val title = document.select("h1.title").text()
        val poster = document.select(".poster img").attr("src")
        val year = document.select(".year").text().toIntOrNull()
        val plot = document.select(".plot").text()

        return newMovieLoadResponse(title, url, TvType.Movie, url) {
            this.posterUrl = poster
            this.year = year
            this.plot = plot
        }
    }

    override suspend fun search(query: String): List<SearchResponse> {
        val document = app.get("$mainUrl/?s=$query").document
        return document.select(".film-listesi .film").map { film ->
            val title = film.select("h2").text()
            val href = film.select("a").attr("href")
            newMovieSearchResponse(title, href, TvType.Movie) {
                posterUrl = film.select("img").attr("src")
            }
        }
    }
}
