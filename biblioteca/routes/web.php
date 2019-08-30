<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', 'BibliotecaController@index')->name('inicio');

Auth::routes();

Route::get('/home', 'HomeController@index')->name('home');

Route::get('/Biblioteca/{id}', 'BibliotecaController@cursos')->name('biblioteca.inicio');

Route::get('/Detalle/{id}', 'BibliotecaController@detalle')->name('detalle');

