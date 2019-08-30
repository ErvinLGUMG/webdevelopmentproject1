<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

use GuzzleHttp\Client;
use GuzzleHttp\Exeption\GuzzleException;

use function GuzzleHttp\json_decode;

class BibliotecaController extends Controller
{
    public function index(){

        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Category/ListCategory');
        $menu = $request->getBody();


        return view('welcome',['menu'=> json_decode($menu)]);
    }



    public function cursos($id){

        $client = new Client();
        $request = $client->get('http://40.117.209.118/LibraryApi/api/Category/ListCategory');
        $menu = $request->getBody();


         // return ['title'=>$id, 'menu' => json_decode($menu)];
        //return view('biblioteca.inicio')->withTitle($id);
       return view('biblioteca.inicio',['title'=>$id, 'menu' => json_decode($menu)]);

    }

    public function detalle(){
        //return "hola mundo ";
        return view('biblioteca.detalle');
    }
}
