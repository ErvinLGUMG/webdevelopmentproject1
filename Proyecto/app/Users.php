<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class User extends Model
{
    protected $table="user";

    protected function roles(){
        return $this->belongsToMany("App\Roles");
    }
}
